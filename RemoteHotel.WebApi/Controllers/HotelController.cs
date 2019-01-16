using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RemoteHotel.DAL;
using RemoteHotel.DAL.Methods;
using RemoteHotel.DAL.Models;
using RemoteHotel.WebApi.Attributes;
using RemoteHotel.WebApi.Models;

namespace RemoteHotel.WebApi.Controllers
{
    [RoutePrefix("api")]
    [TokenAuthenticate]
    public class HotelController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public HotelController()
        {
            this._unitOfWork = new UnitOfWork(new RemoteHotelContext());
        }

        //[HttpGet]
        //public IHttpActionResult GetAllHotelsData()
        //{
        //    var hotels = this._unitOfWork.Hotels.GetAll().Select(x =>
        //    new HotelViewModel
        //    {
        //        HotelId = x.Id,
        //        HotelName = x.HotelName,
        //        Floors = x.Floors.Select(z =>
        //            new FloorViewModel
        //            {
        //                FloorId = z.Id,
        //                Level = z.Level,
        //                Rooms = z.Rooms.Select(y =>
        //                    new RoomViewModel
        //                    {
        //                        RoomNumber = y.RoomNumber,
        //                        Beds = y.Beds,
        //                        Standard = y.Standard
        //                    })
        //            })
        //    });
        //    return Ok(hotels);
        //}

        [HttpGet]
        [Route("hotels")]
        public IHttpActionResult GetHotels()
        {
            var hotels = this._unitOfWork.Hotels.GetAll().Select(x => new HotelViewModel()
            {
                HotelId = x.Id,
                HotelName = x.HotelName
            });
            return Ok(hotels);
        }

        //[HttpGet]
        //[Route("HotelData/{hotelId}")]
        //public IHttpActionResult GetFloorsByHotel(int hotelId)
        //{
        //    var hotelData = this._unitOfWork.Floors.GetFloorsByHotel(hotelId).Select(x => new FloorViewModel()
        //    {
        //        FloorId = x.Id,
        //        Level = x.Level,
        //        Rooms = x.Rooms.Select(y => new RoomViewModel()
        //        {
        //            RoomNumber = y.RoomNumber,
        //            Standard = y.Standard,
        //            Beds = y.Beds
        //        })

        //    });
        //    return Ok(hotelData);
        //}
        //[HttpPost]
        //[Route("AddFloor")]
        //public IHttpActionResult AddFloorToHotel([FromBody]FloorViewModel floor)
        //{
        //    Floor newFloor = new Floor();
        //    newFloor.Level = floor.Level;
        //    newFloor.HotelId = floor.HotelId;

        //    this._unitOfWork.Floors.Add(newFloor);


        //    return Ok(this._unitOfWork.Complete());
        //}

        [HttpPost]
        [Route("hotels")]
        public IHttpActionResult AddHotel([FromBody]HotelViewModel hotel)
        {
            Hotel newHotel = new Hotel();
            newHotel.HotelName = hotel.HotelName;
            this._unitOfWork.Hotels.Add(newHotel);

            this._unitOfWork.Complete();

            return Ok(newHotel.Id);

        }
    }
}
