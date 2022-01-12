using Persons.DTOs;

namespace Persons.Services;

public class PersonService
{
    private PersonsContext personsContext;

    public PersonService(PersonsContext personsContext)
    {
        this.personsContext = personsContext;
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
