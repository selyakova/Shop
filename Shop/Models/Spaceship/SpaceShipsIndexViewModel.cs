namespace Shop.Models.Spaceship
{
    public class SpaceshipIndexViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Passengers { get; set; }
        public int EnginePower { get; set; }
    }
}
