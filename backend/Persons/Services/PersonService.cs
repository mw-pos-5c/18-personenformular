using System.Text.RegularExpressions;

using Persons.DTOs;

namespace Persons.Services;

public class PersonService
{
    private PersonsContext personsContext;
    private Regex addressRegex;
    
    public PersonService(PersonsContext personsContext)
    {
        this.personsContext = personsContext;
        addressRegex = new Regex(@"(\w)-(\d{4})\s(\w+),\s(\w+)\s(\d)");
    }

    public IEnumerable<PersonResponseDto> GetAllPersons()
    {
        return personsContext.Persons.Include(person => person.Adress).Include(person => person.Adress.City).Select(person => GetPersonResponseDto(person));
    }

    public PersonResponseDto GetPerson(long id)
    {
        Person? person = personsContext.Persons.FirstOrDefault(person => person.Id == id);
        return person == null
            ? null
            : GetPersonResponseDto(person);
    }

    public long AddPerson(PersonDto dto)
    {
        Match match = addressRegex.Match(dto.Address);

        if (!match.Success)
        {
            return -1;
        }
        var city = new City
        {
            CountryCode = match.Groups[1].Value,
            PostalCode = int.Parse(match.Groups[2].Value),
            Name = match.Groups[3].Value
        };

        var address = new Adress
        {
            City = city,
            StreetName = match.Groups[4].Value,
            StreetNr = int.Parse(match.Groups[5].Value)
        };

        var person = new Person
        {
            Firstname = dto.Firstname,
            Lastname = dto.Lastname,
            Tel = dto.Tel,
            Born = dto.Born,
            Adress = address
        };

        personsContext.Persons.Add(person);
       personsContext.SaveChanges();

       return person.Id;
    }

    private static PersonResponseDto GetPersonResponseDto(Person person)
    {
        return new PersonResponseDto
        {
            Id = person.Id,
            Address = $"{person.Adress.City.CountryCode}-{person.Adress.City.PostalCode} {person.Adress.City.Name}, {person.Adress.StreetName} {person.Adress.StreetNr}",
            Born = person.Born,
            Firstname = person.Firstname,
            Lastname = person.Lastname,
            Tel = person.Tel
        };
    }
    
}
