namespace MVCBasics.ViewModels
{
    public class ViewModelsContainer // "Container class" used by PeopleController to send multiple view models to view
    {
        public CountriesViewModel Countries { get; set; } = new();

        public CitiesViewModel Cities { get; set; } = new();

        public PeopleViewModel People { get; set; } = new();

        public CreatePersonViewModel CreatePerson { get; set; } = new();
    }
}
