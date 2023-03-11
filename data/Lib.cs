using Microsoft.AspNetCore.Identity;

namespace TravelCompany.data
{
    public class Lib
    {
        public static async Task addDefulte(IServiceProvider provider)
        {
            var scopFactory = provider.GetRequiredService<IServiceScopeFactory>();
            var region = scopFactory.CreateScope();
            var reg = region.ServiceProvider.GetRequiredService<IRepository<Region>>();
            var db = scopFactory.CreateScope();
            var database = db.ServiceProvider.GetRequiredService<ApplicationDBContext>();
            var role = scopFactory.CreateScope();
            var ro = role.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if(!await ro.RoleExistsAsync("User")) {
                IdentityRole rol = new IdentityRole { Name = "User",NormalizedName="User"};
                await ro.CreateAsync(rol);
            }
            var regions = await reg.GetAll()!;
            if (regions.Count != 14)
            {                
                List<Region> regiones = new List<Region>
                    {
                        new Region {id = "al",enRegion = "Aleppo",arRegion = "حلب" },
                        new Region {id = "id",enRegion = "Idleb",arRegion = "إدلب" },
                        new Region {id = "de",enRegion = "Der alzor",arRegion = "دير الزور" },
                        new Region {id = "ha",enRegion = "Hama",arRegion = "حماه" },
                        new Region {id = "ta",enRegion = "Tartos",arRegion = "طرطوس" },
                        new Region {id = "la",enRegion = "Latakai",arRegion = "اللازقية" },
                        new Region {id = "da",enRegion = "Damascose",arRegion = "دمشق" },
                        new Region {id = "ho",enRegion = "Homs",arRegion = "حمص" },
                        new Region {id = "dr",enRegion = "Daraa",arRegion = "درعا" },
                        new Region {id = "ka",enRegion = "Alkamshle",arRegion = "القامشلي" },
                        new Region {id = "rd",enRegion = "Ref damascose",arRegion = "ريف دمشق" },
                        new Region {id = "hs",enRegion = "Alhasaka",arRegion = "الحسكة" },
                        new Region {id = "td",enRegion = "Tadmor",arRegion = "تدمر" },
                        new Region {id = "ra",enRegion = "Alraqa",arRegion = "الرقة" }
                    };
                foreach (Region r in regiones)
                {
                    try
                    {
                        if (!regions.Where(a => a.id == r.id).Any())
                        {
                            reg.Add(r);
                            reg.Save();
                        }
                    }
                    catch { throw; }
                }
            }
        }
    }
}
