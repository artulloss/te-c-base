using System.Collections.Generic;
using System.Linq;
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
        
        public HotelsController()
        {
            _hotelDao = new HotelDao();
        }

        [HttpGet("hotels")]
        public List<Hotel> ListHotels()
        {
            return _hotelDao.List();
        }

        [HttpGet("hotels/{id}")]
        public Hotel GetHotel(int id)
        {
            return _hotelDao.Get(id);
        }

        [HttpGet("filter")]
        public List<Hotel> FilterByCityState(string state, string city) {
            return _hotelDao.List().Where(h => h.Address.State == state && city == null || h.Address.City == city).ToList();
        }
    }
}
