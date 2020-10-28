using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("/")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static IHotelDao _hotelDao;
        private static IReservationDao _reservationDao;

        
        public HotelsController()
        {
            
            _hotelDao = new HotelDao();
            _reservationDao = new ReservationDao();
        }

        [HttpGet("hotels")]
        public List<Hotel> ListHotels()
        {
            return _hotelDao.List();
        }

        [HttpGet("hotels/{id}")]
        public Hotel GetHotel(int id)
        {
           
            Hotel hotel = _hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }

            return null;
        }


        [HttpGet("reservations")]
        public List<Reservation> GetReservations()
        {

            return _reservationDao.List();

        }

        [HttpGet("reservations/{id}")]
        public Reservation GetReservation(int id)
        {

            Reservation reservation = _reservationDao.Get(id);

            if (reservation != null)
            {
                return reservation;
            }

            return null;
        }

        [HttpGet("hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservationsForHotel(int hotelId)
        {

            return _reservationDao.FindByHotel(hotelId);

        }


        [HttpPost("reservations")]
        public Reservation AddReservation(Reservation reservation)
        {

            return _reservationDao.Create(reservation);

        }

        [HttpGet("hotels/filter")]
        public List<Hotel> FilterByCityState(string state, string city)
        {

            List<Hotel> filteredHotels = new List<Hotel>();

            List<Hotel> hotels = _hotelDao.List();

            foreach(Hotel hotel in hotels)
            {
                if (hotel.Address.State.ToLower() == state.ToLower())
                {
                    filteredHotels.Add(hotel);
                }
            }

            return filteredHotels;

        }

    }
}
