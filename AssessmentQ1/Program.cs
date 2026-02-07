using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentBooking
{
    // 1. The Seat Class
    public class Seat
    {
        public int SeatNo { get; set; }
        public bool IsBooked { get; set; }
        public string BookedBy { get; set; }

        // This object serves as the "Guard" for this specific seat
        public readonly object SeatLock = new object();

        public Seat(int seatNo)
        {
            SeatNo = seatNo;
            IsBooked = false;
        }
    }

    public class TicketSystem
    {
        // Dictionary for O(1) lookup speed
        private Dictionary<int, Seat> seats = new Dictionary<int, Seat>();

        public TicketSystem(int totalSeats)
        {
            for (int i = 1; i <= totalSeats; i++)
            {
                seats.Add(i, new Seat(i));
            }
        }

        // 2. The Thread-Safe Booking Method
        public bool BookSeat(int seatNo, string userId)
        {
            // Step 1: Check if seat exists
            if (!seats.ContainsKey(seatNo))
            {
                Console.WriteLine($"Error: Seat {seatNo} does not exist.");
                return false;
            }

            Seat selectedSeat = seats[seatNo];

            // Step 2: LOCK the specific seat. 
            // While this block runs, no other thread can touch THIS seat's lock.
            lock (selectedSeat.SeatLock)
            {
                // CRITICAL SECTION START
                if (selectedSeat.IsBooked)
                {
                    // Someone beat us to it inside the lock
                    return false;
                }

                // Book it
                selectedSeat.IsBooked = true;
                selectedSeat.BookedBy = userId;
                return true;
                // CRITICAL SECTION END
            }
        }
    }

    // 3. Testing it with Threads
    class Program
    {
        static void Main(string[] args)
        {
            TicketSystem system = new TicketSystem(10); // 10 Seats

            // Simulate 5 users trying to book Seat #1 at the same time
            Parallel.For(0, 5, i =>
            {
                string user = $"User_{i}";
                bool success = system.BookSeat(1, user);

                if (success)
                    Console.WriteLine($"{user} booked Seat 1 SUCCESSFULLY.");
                else
                    Console.WriteLine($"{user} FAILED to book Seat 1 (Already taken).");
            });
        }
    }
}