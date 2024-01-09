namespace HospitalService.Data;
public class Seed
{
    public static async Task SeedHospitals(ApplicationDbContext context)
        {
            if (await context.Hospitals.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/Seed/overview-erasmus-site.json");
            var emp = JsonSerializer.Deserialize<List<Class_Hospital>>(userData);
            if(emp != null){
            foreach (var item in emp) { 
                context.Hospitals.Add(item);
                 }
            await context.SaveChangesAsync();
            }
        }
        public static async Task SeedCountries(ApplicationDbContext context)
        {
            if (await context.Countries.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/Seed/countrySeedData.json");
            var emp = JsonSerializer.Deserialize<List<ClassCountry>>(userData);
            if(emp != null){
            foreach (var item in emp) { context.Countries.Add(item); }
            await context.SaveChangesAsync();
            }
        }
}