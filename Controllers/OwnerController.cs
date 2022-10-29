using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Owner.API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private static List<OwnerModel> OwnerList = new List<Model.OwnerModel>
        {
                new Model.OwnerModel
                {
                    Id = 1,
                    FirstName = "David",
                    Surname = "Chalmers",
                    Date = DateTime.Now,
                    Description = "Desc 1",
                    Type = "Philosophy of Mind"
                },
                new Model.OwnerModel
                {
                    Id = 2,
                    FirstName = "Thomas",
                    Surname = "Kuhn",
                    Date = DateTime.Now,
                    Description = "Desc 2",
                    Type = "Philosophy of Science"
                },
                new Model.OwnerModel
                {
                    Id = 3,
                    FirstName = "Nicholas",
                    Surname = "Joll",
                    Date = DateTime.Now,
                    Description = "Desc 3",
                    Type = "Meta-Philosophy"
                },
                new Model.OwnerModel
                {
                    Id = 4,
                    FirstName = "Ludwig",
                    Surname = "Wittgenstein",
                    Date = DateTime.Now,
                    Description = "Desc 4",
                    Type = "Philosophy of Language"
                },
                new Model.OwnerModel
                {
                    Id = 5,
                    FirstName = "Stephen",
                    Surname = "Ferguson",
                    Date = DateTime.Now,
                    Description = "Desc 5",
                    Type = "Philosophy of Mathematics"
                },
                new Model.OwnerModel
                {
                    Id = 6,
                    FirstName = "Hannah",
                    Surname = "Arendt",
                    Date = DateTime.Now,
                    Description = "Desc 6",
                    Type = "Philosophy of Law"
                },
                new Model.OwnerModel
                {
                    Id = 7,
                    FirstName = "Niels Henrik",
                    Surname = "Bohr",
                    Date = DateTime.Now,
                    Description = "Desc 7",
                    Type = "Interpretations of Quantum Mechanics"
                },
                new Model.OwnerModel
                {
                    Id = 8,
                    FirstName = "Ahmet",
                    Surname = "Cevizci",
                    Date = DateTime.Now,
                    Description = "Desc 8",
                    Type = "Ephistemology"
                },
                new Model.OwnerModel
                {
                    Id = 9,
                    FirstName = "Ioanna",
                    Surname = "Kuçuradi",
                    Date = DateTime.Now,
                    Description = "Desc 9",
                    Type = "Value Philosohy"
                },
                new Model.OwnerModel
                {
                    Id = 10,
                    FirstName = "Baruch",
                    Surname = "Spinoza",
                    Date = DateTime.Now,
                    Description = "Desc 10",
                    Type = "Philosopyh of Religion"
                },
        };

        [HttpGet]
        public IActionResult GetList()
        {
            var ownerDatas = OwnerList.ToList();
            return Ok(ownerDatas);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Create(OwnerModel owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }

            if (owner.Description.ToLower().Contains("hack"))
            {
                return BadRequest("You cannot write 'hack' words in the description.");
            }

            OwnerList.Add(owner);
            return Ok(owner);
        }

        [HttpPut("{id:int}")]
        [Consumes("application/json")]
        public IActionResult Update(int id, OwnerModel owner)
        {
            if (id != owner.Id)
            {
                return BadRequest("Id's did not match.");
            }

            if (owner.Description.ToLower().Contains("hack"))
            {
                return BadRequest("You cannot write 'hack' words in the description.");
            }

            var ownerData = OwnerList.FirstOrDefault(x => x.Id == id);
            if (ownerData == null)
            {
                return NotFound();
            }

            ownerData.FirstName = owner.FirstName;
            ownerData.Surname = owner.Surname;
            ownerData.Date = owner.Date;
            ownerData.Description = owner.Description;
            ownerData.Type = owner.Type;
            return Ok(owner);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var data = OwnerList.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return NotFound($"Owner with id {id} not found.");
            }

            OwnerList.Remove(data);
            return Ok("Record successfully deleted.");
        }
    }
}
