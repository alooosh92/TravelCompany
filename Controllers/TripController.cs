using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Reflection.Metadata.Ecma335;
using TravelCompany.data;
using TravelCompany.VModels;

namespace TravelCompany.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        IRepositoryBooking _dbBooking;
        IRepositoryBuses _dbBuses;
        IRepository<Companies> _dbCompanies;
        IRepositoryNotes _dbNotes;
        IRepository<PersonInfo> _dbPersonInfo;
        IRepository<Region> _dbRegion;
        IRepositorySeates _dbSeates;
        IRepositoryTrips _dbTrips;
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        ILogger<User> _logger;
        IAuthService _authService;
        public TripController(IRepositoryBooking dbBooking, IRepositoryBuses dbBuses, IRepository<Companies> dbCompany, IRepositoryNotes dbNotes, IRepository<PersonInfo> dbPersonInfo, IRepository<Region> dbRegion, IRepositorySeates dbSeates, IRepositoryTrips dbTrip, UserManager<User> userManager, SignInManager<User> signInManager, ILogger<User> logger,IAuthService authService)
        {
            _dbBooking = dbBooking;
            _dbBuses = dbBuses;
            _dbCompanies = dbCompany;
            _dbNotes = dbNotes;
            _dbPersonInfo = dbPersonInfo;
            _dbRegion = dbRegion;
            _dbSeates = dbSeates;
            _dbTrips = dbTrip;
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _authService= authService;
        }
        [HttpGet]
        [Route("GetTripUser")]
        public async Task<ActionResult<IEnumerable<VMTripsUser>>> GetTripUser()
        {
            if (_dbTrips == null)
            {
                return NotFound();
            }
            List<VMTripsUser> list = new List<VMTripsUser> ();
            var tr = await _dbTrips.GetAll()!;
            foreach(var element in tr)
            {
                List<NotesCompany> notes = await _dbNotes.getCompanyNotes(element!.buses!.companies!.id!)!;
                VMTripsUser trip = new VMTripsUser();
                trip.id = element.id;
                trip.shortName = element.buses!.companies!.shortName;
                trip.busLine = element.from!.arRegion + " - " + element.to!.arRegion;
                trip.dateTime = element.date!;
                trip.color = element.buses.companies.color;
                trip.notes = new List<string>();
                trip.vip = element.buses.vip;
                trip.minutes = element.minutes;
                trip.price = element.price;
                foreach(var note in notes)
                {
                    trip.notes!.Add(note.note!);
                }
                list.Add(trip);
            }
            return list;
        }
        [HttpGet]
        [Route("GetTripCompany")]
        public async Task<ActionResult<IEnumerable<VMTripsCompany>>> GetTripCompany(string companyId)
        {
            if (_dbTrips == null)
            {
                return NotFound();
            }
            List<VMTripsCompany> list = new List<VMTripsCompany>();
            var tr = await _dbTrips.companyTrips(companyId)!;
            foreach (var element in tr)
            {
                int chair = 0;
                List<VMSeat> chairnotAvilibal = new List<VMSeat>();
                List<Booking> booking = await _dbBooking.tripBookign(element.id!)!;
                foreach(var book in booking) {
                   chair = chair + int.Parse(book.numSeates!.ToString()!);
                   List<Seates> seates = await _dbSeates.GetSeatesBooking(book.id!)!;
                    foreach (var seate in seates)
                    {
                        VMSeat seat = new VMSeat();
                        seat.seatNumber = int.Parse(seate.seatNumber!.ToString()!);
                        seat.fullName = seate!.booking!.personInfo!.firstName +" "+ seate!.booking!.personInfo!.fatherName+ " " + seate!.booking!.personInfo!.lastName;
                        chairnotAvilibal.Add(seat);
                    }
                }
                VMTripsCompany trip = new VMTripsCompany();
                trip.id = element.id;               
                trip.busLine = element.from!.enRegion + " - " + element.to!.enRegion;
                trip.dateTime = element.date!;
                trip.busesNumber = element.buses!.busNumber;
                trip.isFull = element.isFull;
                trip.vip = element.buses!.vip;
                trip.chairAvailable = element.buses.seatsNumber - chair;
                trip.chairAvailableNumber = chairnotAvilibal;
                list.Add(trip);
            }
            return list;
        }
        
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("GetRegion")]        
        public async Task<ActionResult<IEnumerable<Region>>> GetRegion()
        {
            try
            {
                 return await _dbRegion.GetAll()!;
            }
            catch { return NotFound(); }
        }
        [HttpGet]
        [Route("GetPersonInfoId")]
        public async Task<ActionResult<PersonInfo>> GetPersonInfoId(string id)
        {
            try
            {
                return await _dbPersonInfo.Get(id)!;
            }
            catch { return NotFound(); }
        }
        [HttpGet]
        [Route("GetBusCompany")]
        public async Task<ActionResult<IEnumerable<VMBusesCompnay>>> GetBusCompany(string id)
        {
            if(_dbBuses == null) return NotFound();
            List<VMBusesCompnay> list = new List<VMBusesCompnay>();
            var buses = await _dbBuses.GetBusesCompany(id)!;
            foreach(var bus in buses)
            {
                if (bus.active == true)
                {
                    VMBusesCompnay vmb = new VMBusesCompnay();
                    vmb.id = bus.id;
                    var v = "";
                    if (bus.vip == true) v = "VIP";
                    vmb.busInfo =String.Format("N:{0} - {1}{2} - S:{3} {4}", 
                        bus.busNumber, 
                        bus.region!.arRegion,
                        bus.paletNumber,
                        bus.seatsNumber,
                        v);                    
;                    list.Add(vmb);
                }
            }
            return list;
        }
        [HttpGet]
        [Route("GetBookingUser")]
        public async Task<ActionResult<IEnumerable<VMBookingUser>>> GetBookingUser(string userId)
        {     
            if(_dbBooking == null) return NotFound();
            List<Booking> booking = await _dbBooking.userBookign(userId)!;
            List<VMBookingUser> vMBookList = new List<VMBookingUser>();
            foreach(Booking book in booking)
            {
                List<Seates> seate = await _dbSeates.GetSeatesBooking(book.id!)!;
                List<int?> sss = new List<int?>();
                foreach(Seates s in seate)
                {
                    sss.Add(s.seatNumber);
                }
                VMBookingUser vMBook = new VMBookingUser
                {
                    from = book.trips!.from!.arRegion,
                    to = book.trips.to!.arRegion,
                    vip = book.trips.buses!.vip,
                    price = book.trips.price!,
                    busNumber = book.trips.buses!.busNumber,
                    color = book.trips.buses.companies!.color,
                    dateTimeBooking = book.DateTime,
                    dateTimeTravel = book.trips.date,
                    id = book.id,
                    isCheck = book.isCheck,
                    isPay = book.isPay,
                    seateNumber = book.numSeates,
                    shortName = book.trips.buses.companies.name,
                    seates = sss
                };
                vMBookList.Add(vMBook);
            }
            return vMBookList;
        }
        [HttpGet]
        [Route("GetBookingCompany")]
        public async Task<ActionResult<IEnumerable<VMBookingCompany>>> GetBookingCompany(string companyId)
        {
            if (_dbBooking == null) return NotFound();
            List<Booking> booking = await _dbBooking.companyBookign(companyId)!;
            List<VMBookingCompany> vMBookList = new List<VMBookingCompany>();
            foreach (Booking book in booking)
            {
                List<Seates> seate = await _dbSeates.GetSeatesBooking(book.id!)!;
                List<int?> sss = new List<int?>();
                foreach (Seates s in seate)
                {
                    sss.Add(s.seatNumber);
                }
                VMBookingCompany vMBook = new VMBookingCompany
                {
                    busLine = book.trips!.from!.enRegion + " - " + book.trips!.to!.enRegion,
                    busNumber = book.trips.buses!.busNumber,
                    dateTimeBooking = book.DateTime,
                    dateTimeTravel = book.trips.date,
                    id = book.id,
                    isCheck = book.isCheck,
                    isPay = book.isPay,
                    seateNumber = book.numSeates,
                    seates = sss
                };
                vMBookList.Add(vMBook);
            }
            return vMBookList;
        }        
        [HttpPost]
        [Route("PostBookingUser")]
        public async Task<bool> PostBookingUser([FromBody] VMBookingPostUser booking)
        {
            try
            {
                Booking book = new Booking();
                book.id = Guid.NewGuid().ToString();
                book.DateTime = DateTime.Now;
                book.isCheck = false;
                book.isPay = false;
                book.noteUser = booking.note;
                book.noteCompany = "";
                book.user = booking.userId;
                book.numSeates = booking.numSeate;
                book.personInfo = await _dbPersonInfo.Get(booking!.personId!)!;
                book.trips = await _dbTrips.Get(booking!.tripId!)!;
                _dbBooking.Add(book);
                _dbBooking.Save();
                return true;
            }
            catch { return false; }
        }
        [HttpPost]
        [Route("PostBookingCompany")]
        public async Task<bool> PostBookingCompany([FromBody] VMBookingPostCompany booking)
        {
            try
            {
                Booking book = new Booking();
                book.id = Guid.NewGuid().ToString();
                book.DateTime = DateTime.Now;
                book.isCheck = true;
                book.isPay = booking.isPay;
                book.noteCompany = booking.note;
                book.noteUser = "";
                book.user = booking.userId;
                book.numSeates = booking.numSeate;
                book.personInfo = await _dbPersonInfo.Get(booking!.personId!)!;
                book.trips = await _dbTrips.Get(booking!.tripId!)!;
                _dbBooking.Add(book);
                foreach (var seate in booking.seates!)
                {
                    Seates s = new Seates();
                    s.id = Guid.NewGuid().ToString();
                    s.seatNumber = seate;
                    s.booking = book;
                    _dbSeates.Add(s);
                }
                _dbBooking.Save();
                return true;
            }
            catch { return false; }
        }
        [HttpPost]
        [Route("PostBuses")]
        public async Task<bool> PostBus([FromBody] VMBus bus)
        {
            try
            {
                Buses b = new Buses();
                b.paletNumber = bus.paletNumber;
                b.busNumber = bus.busNumber;
                b.seatsNumber = bus.seatsNumber;
                b.id = Guid.NewGuid().ToString();
                b.companies = await _dbCompanies.Get(bus.companyId!)!;
                b.active = bus.active;
                b.vip = bus.vip;
                b.region = await _dbRegion.Get(bus.regionId!)!;
                _dbBuses.Add(b);
                _dbBuses.Save();
                return true;
            }
            catch { return false; }
        }
        [HttpPost]
        [Route("PostCompany")]
        public bool PostCompany([FromBody] VMCompany company)
        {
            try
            {
                Companies com = new Companies();
                com.id = Guid.NewGuid().ToString();
                com.phone = company.phone;
                com.name = company.name;
                com.shortName = company.shortName;
                com.active = company.active;
                com.color = company.color;                
                _dbCompanies.Add(com);
                foreach (var note in company.notes!)
                {
                    NotesCompany n = new NotesCompany();
                    n.id = Guid.NewGuid().ToString();
                    n.companies = com;
                    n.note = note;
                    _dbNotes.Add(n);
                }
                _dbCompanies.Save();
                return true;
            }
            catch { return false; }
        }
        [HttpPost]
        [Route("PostPerson")]
        public async Task<bool> PostPerson([FromBody] VMPostPerson person)
        {
            try
            {
                PersonInfo per = new PersonInfo
                {
                    userId = person.userId,
                    nationalNumber = person.nationalNumber,
                    lastName = person.lastName,
                    phone = person.phone,
                    birthDay =DateTime.Parse(person.birthDay!),
                    firstName = person.firstName,
                    motherName = person.motherName,
                    fatherName = person.fatherName,
                    amana = person.amana,
                    kayed = person.kayed,
                    sex = person.sex,
                    region = await _dbRegion.Get(person.region!)!                    
                };
                _dbPersonInfo.Add(per);
                _dbPersonInfo.Save();
                return true;
            }catch { return false; }
        }
        [HttpPost]
        [Route("PostTip")]
        public async Task<bool> PostTrip([FromBody] VMTrip trip)
        {
            try
            {
                Trips tr = new Trips();
                tr.id = Guid.NewGuid().ToString();
                tr.isFull = false;
                tr.price = trip.price;
                tr.minutes = trip.minutes;
                tr.date = trip.date;
                tr.buses = await _dbBuses.Get(trip.buses!)!;
                tr.to = await _dbRegion.Get(trip.to!)!;
                tr.from = await _dbRegion.Get(trip.from!)!;
                _dbTrips.Add(tr);
                _dbTrips.Save();
                return true;
            }catch { return false; }
        }
        [HttpPut()]
        [Route("UpdateBookingUser")]
        public async Task<bool> PutBookingUpdateUser(string id, [FromBody] VMBookingUpdateUser booking)
        {
            try {
                Booking book = await _dbBooking.Get(id)!;
                if (book.isCheck == true) { book.isPay = booking.isPay; }
                else
                {
                    book.noteUser = booking.noteUser;
                    book.numSeates = booking.numSeate;
                }
                _dbBooking.Update(book);
                _dbBooking.Save();
                return true;
            }catch { return false; }
        }
        [HttpPut]
        [Route("UpdateBookingCompany")]
        public async Task<bool> UpdateBookingCompany(string id, [FromBody] VMBookingUpdateCompany booking)
        {
            try
            {
                Booking book = await _dbBooking.Get(id)!;
                if (book.isCheck == true) { book.isPay = booking.isPay; }
                else
                {
                    book.noteCompany = booking.noteComoapny;
                    book.isPay = booking.isPay;
                    book.isCheck = booking.isCheak;
                    _dbBooking.Update(book);
                    if (booking.seat!.Count > 0)
                    {
                        List<Seates> se = await _dbSeates.GetSeatesBooking(id)!;
                        if (se.Count > 0)
                        {
                            foreach (Seates se1 in se)
                            {
                                _dbSeates.Delete(se1);
                            }
                        }
                    }
                    foreach (var seat in booking.seat!)
                    {
                        Seates s = new Seates();
                        s.id = Guid.NewGuid().ToString();
                        s.seatNumber = seat;
                        s.booking = book;
                        _dbSeates.Add(s);
                    }
                }
                _dbBooking.Save();
                return true;
            }
            catch { return false; }
        }
        [HttpPut]
        [Route("UpdateBus")]
        public async Task<bool> UpdateBus(string id, [FromBody] VMBusUpdate bus)
        {
            try
            {
                Buses b = await _dbBuses.Get(id)!;
                b.paletNumber = bus.paletNumber;
                b.busNumber = bus.busNumber;
                b.seatsNumber = bus.seatsNumber;
                b.active = bus.active;
                b.vip = bus.vip;
                b.region = await _dbRegion.Get(bus.region!)!;
                _dbBuses.Update(b);
                _dbBuses.Save();
                return true;
            }
            catch { return false; }
        }
        [HttpPut]
        [Route("UpdateCompany")]
        public async Task<bool> UpdateCompany(string id, [FromBody] VMCompany company)
        {
            try
            {
                Companies com = await _dbCompanies.Get(id)!;
                com.phone = company.phone;
                com.name = company.name;
                com.shortName = company.shortName;
                com.active = company.active;
                com.color = company.color;
                _dbCompanies.Update(com);
                List<NotesCompany> notes = await _dbNotes.getCompanyNotes(id)!;
                foreach(var note in notes)
                {
                    _dbNotes.Delete(note);
                }
                foreach (var note in company.notes!)
                {
                    NotesCompany n = new NotesCompany();
                    n.id = Guid.NewGuid().ToString();
                    n.companies = com;
                    n.note = note;
                    _dbNotes.Add(n);
                }
                _dbCompanies.Save();
                return true;
            }
            catch { return false; }
        }
        [HttpPut]
        [Route("UpdatePersonInfo")]
        public async Task<bool> UpdatePersonInfo(string id, [FromBody] VMPerson person) 
        {
            try {
                PersonInfo per = await _dbPersonInfo.Get(id)!;
                per.userId = person.userId;
                per.nationalNumber = person.nationalNumber;
                per.lastName = person.lastName;
                per.phone = person.phone;
                per.birthDay = person.birthDay;
                per.firstName = person.firstName;
                per.motherName = person.motherName;
                per.fatherName = person.fatherName;
                per.amana = person.amana;
                per.kayed = person.kayed;
                per.sex = person.sex;
                per.region = await _dbRegion.Get(person.region!)!;
                _dbPersonInfo.Update(per);
                _dbPersonInfo.Save();
                return true; 
            } catch { return false; }
        }
        [HttpPut]
        [Route("UpdateTip")]
        public async Task<bool> UpdateTrip(string id, [FromBody] VMTrip trip)
        {
            try
            {
                Trips tr = await _dbTrips.Get(id)!;
                tr.isFull = trip.isFull;
                tr.price = trip.price;
                tr.minutes = trip.minutes;
                tr.date = trip.date;
                tr.buses = await _dbBuses.Get(trip.buses!)!;
                tr.to = await _dbRegion.Get(trip.to!)!;
                tr.from = await _dbRegion.Get(trip.from!)!;
                _dbTrips.Update(tr);
                _dbTrips.Save();
                return true;
            }
            catch { return false; }
        }


        [HttpDelete]
        [Route("DeleteBooking")]
        public async Task<bool> DeleteBooking(string id)
        {
            try
            {
                Booking book = await _dbBooking.Get(id)!;
                if (book.isPay == true) { return false; }
                _dbBooking.Delete(book);
                _dbBooking.Save();
                return true;
            }
            catch { return false; }
        }


        [HttpPost]
        [Route("PostAddUser")]
        public async Task<IActionResult> PostAddUser([FromBody] VMUser model)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            var result = await _authService.Register(model);
            if(!result.Value!.IsAuthanticated) { return BadRequest(); }
            return Ok(result);
        }
       }
}

