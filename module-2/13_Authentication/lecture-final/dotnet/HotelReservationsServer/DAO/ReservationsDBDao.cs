using HotelReservations.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservations.Dao
{
    public class ReservationsDBDao : IReservationDao
    {
        //TODO fix this later
        private string connectionString = "";
        public Reservation Create(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> FindByHotel(int hotelId)
        {
            var reservations = new List<Reservation>();
            using (SqlConnection conn = new SqlConnection("Server =.\\SQLEXPRESS; Database = hotels; Trusted_Connection = True;"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * from reservations", conn);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) //go to next row if there's still rows to read
                {
                    var id = Convert.ToInt32(reader["id"]);
                    var hId = Convert.ToInt32(reader["hotelid"]);
                    var name = Convert.ToString(reader["fullName"]);
                    var checkinDate = Convert.ToString(reader["checkinDate"]);
                    var checkoutDate = Convert.ToString(reader["checkoutDate"]);
                    var guests = Convert.ToInt32(reader["guests"]);

                    var reseravation = new Reservation(id, hId, name, checkinDate, checkoutDate, guests);
                    reservations.Add(reseravation);
                }
            }

            return reservations;
        }

        public Reservation Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> List()
        {
            throw new NotImplementedException();
        }

        public Reservation Update(int id, Reservation updated)
        {
            throw new NotImplementedException();
        }
    }
}
