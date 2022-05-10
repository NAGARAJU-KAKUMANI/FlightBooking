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
       
        [HttpPost]
        [Route("insert-booking-details")]
        public async Task<IActionResult> InsertUserDetails([FromBody] BookingViewModel bookingViewModel)
        {
            try
            {
                IEnumerable<UsersViewModel> _usersViewModels = bookingViewModel.usersViewModels;
                int setCount = _usersViewModels.Count();
                Inventorys _inventorys=null;
                Bookings bookings;
                if ((Seattype)bookingViewModel.Seattype == 0)
                {
                    _inventorys = _userRepository.GetInventorys().ToList()
                        .Where(o => o.FlightNumber == bookingViewModel.FlightNumber && o.BclassAvailCount>=setCount).FirstOrDefault();
                }
                else if ((Seattype)bookingViewModel.Seattype == 0)
                {
                    _inventorys = _userRepository.GetInventorys().ToList()
                        .Where(o => o.FlightNumber == bookingViewModel.FlightNumber && o.StartDate == bookingViewModel.DateOfJourney
                        && o.startTime == bookingViewModel.BoardingTime && o.NBclassAvailableCount >= setCount).FirstOrDefault();
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
                if ((Seattype)bookingViewModel.Seattype == 0)
                {
                    seatNumber = _inventorys.BClassCount - _inventorys.BclassAvailCount;
                }
                else if ((Seattype)bookingViewModel.Seattype == 0)
                {
                    seatNumber = _inventorys.NBclassAvailableCount - _inventorys.NBclassAvailableCount;
                }
                foreach (UsersViewModel usersViewModel in _usersViewModels)
                {
                    bookings = new Bookings();
                    bookings.TicketID= GenerateticketID();
                    bookings.BookingID = BookingId;
                    bookings.FlightNumber = flightNumber;
                    bookings.DateOfJourney = DateOfJourney;
                    bookings.FromPlace = FromPlace;
                    bookings.ToPlace = ToPlace;
                    bookings.BoardingTime = BoardingTime;
                    bookings.EmailID = EmailID;
                    bookings.UserName = usersViewModel.UserName;
                    bookings.passportNumber = usersViewModel.passportNumber;
                    bookings.Age = usersViewModel.Age;
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
                }
                await _topicProducer.Produce(new BookingEvent { FlightNumber =flightNumber,
                    FromPlace=FromPlace,ToPlace=ToPlace,StartDate=DateOfJourney,startTime=BoardingTime,
                    NumberOfTickets=setCount,Settype= (int) (Seattype)bookingViewModel.Seattype
                });
               

                return Ok("Booking Done Successfully");
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
        [HttpPut]
        [Route("cancel-ticket/{TicketID}")]
        public IActionResult CancelTicket(string TicketID)
        {
            try
            {
                IEnumerable<Bookings> bookings = _userRepository.GetBookings().ToList().Where(o => o.TicketID == TicketID).Take(1);
                foreach (Bookings booking in bookings)
                {
                    booking.Status = 0;
                    booking.Statusstr = "Canceled";
                    using (var scope = new TransactionScope())
                    {
                        _userRepository.UpdateBooking(booking);
                        scope.Complete();

                    }
                }
                return new OkObjectResult(bookings);
            }
            catch
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
                return new OkObjectResult(bookings);
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
