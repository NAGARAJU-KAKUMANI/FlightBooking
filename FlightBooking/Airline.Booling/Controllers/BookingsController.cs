using Airline.Booking.Events;
using Airline.Booking.Models;
using Airline.Booking.Services;
using Airline.Booking.ViewModels;
using MassTransit.KafkaIntegration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Airline.Booking.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        public readonly IBookingRepository _userRepository;
        private ITopicProducer<BookingEvent> _topicProducer;
        public BookingsController(IBookingRepository userRepository, ITopicProducer<BookingEvent> topicProducer)
        {
            _userRepository = userRepository;
            _topicProducer = topicProducer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("insert-booking-details")]
        public async Task<IActionResult> InsertUserDetails([FromBody] BookingViewModel bookingViewModel)
        {
            try
            {
                //IEnumerable<UsersViewModel> _usersViewModels = bookingViewModel.BookingUsers;
                //int setCount = _usersViewModels.Count();
                Inventorys _inventorys=null;
                Bookings bookings;
                if (Convert.ToInt32(bookingViewModel.Seattype)==1)
                {
                    _inventorys = _userRepository.GetInventorys().ToList()
                        .Where(o => o.FlightNumber == bookingViewModel.FlightNumber && o.BclassAvailCount>=1 && o.StartDate >= bookingViewModel.DateOfJourney ).FirstOrDefault();
                }
                else if (Convert.ToInt32(bookingViewModel.Seattype) == 2)
                {
                    _inventorys = _userRepository.GetInventorys().ToList()
                       .Where(o => o.FlightNumber == bookingViewModel.FlightNumber && o.NBclassAvailableCount >= 1 && o.StartDate >= bookingViewModel.DateOfJourney).FirstOrDefault();
                }

                if( _inventorys ==null)
                {
                    return BadRequest("Invalid Flight Number or Seats not Available");
                }
                string BookingId = GenerateBookingID();
                string flightNumber = bookingViewModel.FlightNumber;
                DateTime DateOfJourney = bookingViewModel.DateOfJourney;
                string FromPlace = bookingViewModel.FromPlace;
                string ToPlace = bookingViewModel.ToPlace;
                string BoardingTime = bookingViewModel.BoardingTime;
                string CreatedBy = bookingViewModel.CreatedBy;
                string EmailID = bookingViewModel.EmailID;
              
                int seatNumber = 0;
                if (Convert.ToInt32(bookingViewModel.Seattype) ==1 )
                {
                    seatNumber =(int) (_inventorys.BClassCount - _inventorys.BclassAvailCount)+1;
                }
                else if (Convert.ToInt32(bookingViewModel.Seattype) == 2)
                {
                    seatNumber =(int) (_inventorys.NBclassAvailableCount - _inventorys.NBclassAvailableCount)+1;
                }
                bookings = new Bookings();
                bookings.TicketID = GenerateticketID();
                bookings.BookingID = BookingId;
                bookings.FlightNumber = flightNumber;
                bookings.DateOfJourney = DateOfJourney;
                bookings.FromPlace = FromPlace;
                bookings.ToPlace = ToPlace;
                bookings.BoardingTime = BoardingTime;
                bookings.EmailID = EmailID;
                bookings.UserName = bookingViewModel.UserName;
                bookings.passportNumber = bookingViewModel.passportNumber;
                bookings.Age = bookingViewModel.Age;
                bookings.SeatNumber = seatNumber;
                bookings.Status = 0;
                bookings.Statusstr = "Ticket Booked";
                bookings.CreatedBy = CreatedBy;
                bookings.CreatedDate = DateTime.Now;
                bookings.Seattype = bookingViewModel.Seattype;
                using (var scope = new TransactionScope())
                {
                    _userRepository.Insert(bookings);
                    scope.Complete();
                }
                #region
                //foreach (UsersViewModel usersViewModel in _usersViewModels)
                //{
                //    bookings = new Bookings();
                //    bookings.TicketID= GenerateticketID();
                //    bookings.BookingID = BookingId;
                //    bookings.FlightNumber = flightNumber;
                //    bookings.DateOfJourney = DateOfJourney;
                //    bookings.FromPlace = FromPlace;
                //    bookings.ToPlace = ToPlace;
                //    bookings.BoardingTime = BoardingTime;
                //    bookings.EmailID = EmailID;
                //    bookings.UserName = usersViewModel.UserName;
                //    bookings.passportNumber = usersViewModel.passportNumber;
                //    bookings.Age = usersViewModel.Age;
                //    bookings.SeatNumber = seatNumber;
                //    bookings.Status = 0;
                //    bookings.Statusstr = "Ticket Booked";
                //    bookings.CreatedBy = CreatedBy;
                //    bookings.CreatedDate = DateTime.Now;
                //    bookings.Seattype = bookingViewModel.Seattype;
                //    using (var scope = new TransactionScope())
                //    {
                //        _userRepository.Insert(bookings);
                //        scope.Complete();
                //    }
                //}
                #endregion
                await _topicProducer.Produce(new BookingEvent { FlightNumber =flightNumber,
                    FromPlace=FromPlace,ToPlace=ToPlace,StartDate=DateOfJourney,startTime=BoardingTime,
                    NumberOfTickets=1,Settype= (int) (Seattype)bookingViewModel.Seattype,tickettype=0
                });
                return Accepted(new Status { TicketID = bookings.TicketID });
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Generate UniQue TiketID
        /// </summary>
        /// <returns></returns>
        private string GenerateticketID()
        {
            int count = _userRepository.GetBookings().ToList().Count();
            string strSecretCode = string.Empty;
            string strguid = string.Empty;
            string strYearCode = string.Empty;
            string TicketID = string.Empty;
            try
            {
                System.Guid guid = System.Guid.NewGuid();
                strguid = guid.ToString();
                strSecretCode = strguid.Substring(strguid.LastIndexOf("-") + 1);
                strSecretCode = strSecretCode.ToUpper().Replace('O', 'W').Replace('0', '4');
                strSecretCode = strSecretCode.Substring(0, 6);

                TicketID = "TIC" + strSecretCode.ToUpper()+ count;

                return TicketID;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return TicketID;
            }
           
        }
        /// <summary>
        /// Genarate unique Booking iD
        /// </summary>
        /// <returns></returns>
        private string GenerateBookingID()
        {
            int count = _userRepository.GetBookings().ToList().Count();
            string strSecretCode = string.Empty;
            string strguid = string.Empty;
            string strYearCode = string.Empty;
            string TicketID = string.Empty;
            try
            {
                System.Guid guid = System.Guid.NewGuid();
                strguid = guid.ToString();
                strSecretCode = strguid.Substring(strguid.LastIndexOf("-") + 1);
                strSecretCode = strSecretCode.ToUpper().Replace('O', 'W').Replace('0', '4');
                strSecretCode = strSecretCode.Substring(0, 6);

                TicketID = "BOK" + strSecretCode.ToUpper() + count;

                return TicketID;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return TicketID;
            }

        }

       /// <summary>
       /// Get All User Tickets
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        [Route("get-all-Tickets")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userRepository.GetBookings().ToList();
                return new OkObjectResult(users);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cancel Ticket
        /// </summary>
        /// <param name="TicketID"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("cancel-ticket/{TicketID}")]
        public async Task<IActionResult> CancelTicket(string TicketID)
        {
            try
            {
                IEnumerable<Bookings> bookings = _userRepository.GetBookings().ToList().Where(o => o.TicketID == TicketID).Take(1);
                foreach (Bookings booking in bookings)
                {
                    booking.Status = 1;
                    booking.Statusstr = "Canceled Ticket";
                    using (var scope = new TransactionScope())
                    {
                        _userRepository.UpdateBooking(booking);
                        scope.Complete();
                        await _topicProducer.Produce(new BookingEvent
                        {
                            FlightNumber = booking.FlightNumber,
                            FromPlace = booking.FromPlace,
                            ToPlace = booking.ToPlace,
                            StartDate = booking.DateOfJourney,
                            startTime = booking.BoardingTime,
                            NumberOfTickets = 1,
                            Settype = (int)(Seattype)booking.Seattype,
                            tickettype=1,
                        });
                    }
                }

                return Accepted(new Status {TicketID=TicketID ,CancelStatus = "cancel"});
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// PNR STATUS Check
        /// </summary>
        /// <param name="TicketID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("pnr-ticket/{TicketID}")]
        public IActionResult GetpnrTicket(string TicketID)
        {
            try
            {
                IEnumerable<Bookings> bookings = _userRepository.GetBookings().ToList()
                                                .Where(o => o.TicketID.ToUpper()== TicketID.ToUpper());
                var flights = (from p in bookings

                               where p.TicketID == TicketID
                               select new
                               {
                                   p.TicketID,
                                   p.BookingID,
                                   p.FlightNumber,
                                   p.DateOfJourney,
                                   p.BoardingTime,
                                   p.EmailID,
                                   p.FromPlace,
                                   p.ToPlace,
                                   p.UserName,
                                   p.passportNumber,
                                   p.Age,
                                   TicketType = Enum.GetName(typeof(Seattype), p.Seattype),
                                   p.Statusstr,
                                   p.SeatNumber,p.Status
                                   
                               }).ToList();
                return new OkObjectResult(flights);
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get-all-Inventory")]
        public IActionResult GetallInventory()
        {
            try
            {
                var users = _userRepository.GetInventorys().ToList();
                return new OkObjectResult(users);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
