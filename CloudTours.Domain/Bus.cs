using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTours.Domain
{
    public class Bus
    {
        public Bus(int busId, int busModelId, string registrationPlate, short year, SeatingType seatMapping, int distanceTraveled)
        {
            BusId = busId;
            BusModelId = busModelId;
            RegistrationPlate = registrationPlate;
            Year = year;
            SeatMapping = seatMapping;
            DistanceTraveled = distanceTraveled;
        }

        public int BusId { get; set; }
        public string RegistrationPlate { get; }
        public short Year { get; }
        public SeatingType SeatMapping { get; set; }

        //Coach İçin
        private int _seatCoachRowCount = 0;//Otobüs Uzunluğu
        private const int _seatCoachBlank = 2;//Kapı Önü Sıra(Deluxe ve Premıum)
        private const int _standartCoachSeatRowGroup = 4;
        private const int _deluxeCoachSeatRowGroup = 3;
        private const int _premiumCoachSeatRowGroup = 2;

        public int SeatCount
        {
            get
            {
                if (BusModel.Type == BusType.Coach)
                {
                    if (BusModel.SeatCapacity == 52)
                    {
                        return CoachCount(BusModel.SeatCapacity);
                    }

                    else if (BusModel.SeatCapacity == 48)
                    {
                        return CoachCount(BusModel.SeatCapacity);

                    }

                    else if (BusModel.SeatCapacity == 44)
                    {
                        return CoachCount(BusModel.SeatCapacity);
                    }
                }

                else if (BusModel.Type == BusType.Shuttle)
                {
                    if (BusModel.SeatCapacity == 30)
                    {
                        return ShuttleCount();
                    }

                    if (BusModel.SeatCapacity == 28)
                    {
                        return ShuttleCount();
                    }

                    else if (BusModel.SeatCapacity == 26)
                    {
                        return ShuttleCount();
                    }
                }
                return 0;
            }
        }

        private int CoachCount(int seatCapacity)
        {
            _seatCoachRowCount = seatCapacity / _standartCoachSeatRowGroup + 1;

            if (SeatMapping == SeatingType.Standart)
            {
                return BusModel.SeatCapacity;
            }
            else if (SeatMapping == SeatingType.Deluxe)
            {
                int calculatedRow = _seatCoachRowCount - _seatCoachBlank;
                int calculatedRow01 = _deluxeCoachSeatRowGroup * calculatedRow;
                return calculatedRow01 + _seatCoachBlank;
            }
            else if (SeatMapping == SeatingType.Premium)
            {
                int calculatedRow = _seatCoachRowCount - _seatCoachBlank;
                int calculatedRow01 = _premiumCoachSeatRowGroup * calculatedRow;
                return calculatedRow01 + _seatCoachBlank;
            }
            else
            {
                return 0;
            }
        }

        private int ShuttleCount()
        {
            if (SeatMapping == SeatingType.Standart)
            {
                return BusModel.SeatCapacity;
            }
            else if (SeatMapping == SeatingType.Deluxe)
            {
                return (BusModel.SeatCapacity / 2) + 6;
            }
            else if (SeatMapping == SeatingType.Premium)
            {
                return BusModel.SeatCapacity / 2;
            }
            else
            {
                return 0;
            }
        }

        public int DistanceTraveled { get; set; }

        public int BusModelId { get; }

        public BusModel BusModel { get; set; }
    }
}