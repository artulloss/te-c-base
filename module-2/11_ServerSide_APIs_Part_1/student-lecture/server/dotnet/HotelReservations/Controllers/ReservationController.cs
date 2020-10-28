using System.Collections.Generic;
using HotelReservations.Dao;
using HotelReservations.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservations.Controllers
{
    public class ReservationController : Controller
    {
        private static IReservationDao _reservationDao;

        public ReservationController() {
            _reservationDao = new ReservationDao();
        }
        
        [HttpGet("reservations")]
        public List<Reservation> GetReservations() {
            return _reservationDao.List();
        }

        [HttpGet("reservations/{id}")]
        public Reservation GetReservation(int id) {
            return _reservationDao.Get(id);
        }

        [HttpGet("hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservationsForHotel(int hotelId) {
            return _reservationDao.FindByHotel(hotelId);
        }

        [HttpPost("reservations")]
        public Reservation AddReservation(Reservation reservation) {
            return _reservationDao.Create(reservation);
        }
    }
}