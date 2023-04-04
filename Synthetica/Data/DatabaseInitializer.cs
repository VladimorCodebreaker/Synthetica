using System;
using System.Numerics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Synthetica.Data.Enums;
using Synthetica.Models;
using Synthetica.Data.Static;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Synthetica.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                context.Database.EnsureCreated();

                // Pharmacies
                if (!context.Pharmacies.Any())
                {
                    context.Pharmacies.AddRange(new List<Pharmacy>()
                    {
                        new Pharmacy()
                        {
                            Logo = "/images/pharmacies/0.png",
                            Name = "NeonRX",
                            Description = "This cyberpunk pharmacy specializes in dispensing high-tech medications and other substances, ranging from nootropics to cybernetic implants.                                    "
                        },
                        new Pharmacy()
                        {
                            Logo = "/images/pharmacies/1.png",
                            Name = "The Fixer's Den",
                            Description = "A seedy back-alley drugstore that deals in black-market pharmaceuticals and illicit substances, catering to the underworld's seedier elements.                                   "
                        },
                        new Pharmacy()
                        {
                            Logo = "/images/pharmacies/2.png",
                            Name = "TechPharm",
                            Description = "A high-tech pharmacy that combines cutting-edge medical technology with traditional healing methods, selling everything from nanobots to herbal remedies.                         "
                        },
                        new Pharmacy()
                        {
                            Logo = "/images/pharmacies/3.png",
                            Name = "BioHackers",
                            Description = "A futuristic drugstore that caters to the biohacking subculture, offering a wide range of supplements, enhancers, and experimental therapies."
                        },
                        new Pharmacy()
                        {
                            Logo = "/images/pharmacies/4.png",
                            Name = "Dystopia Drugstore",
                            Description = "A grim and gritty pharmacy that caters to the darker side of cyberpunk life, selling everything from combat stimulants to painkillers to designer drugs with unpredictable effects."
                        },
                    });
                    context.SaveChanges();
                }

                // Substances
                if (!context.Substances.Any())
                {
                    context.Substances.AddRange(new List<Substance>()
                    {
                        new Substance()
                        {
                            Image = "/images/substances/1.png",
                            Name = "NanoMorph",
                            Description = "A nanotechnology-based substance that can be used to alter the molecular structure of other substances, making it a key ingredient in the production of designer drugs."
                        },
                        new Substance()
                        {
                            Image = "/images/substances/2.png",
                            Name = "Synthi-Steel",
                            Description = "A synthetic metal alloy that can be used to create cybernetic implants and drug delivery devices, such as injectors and inhalers.                                     "
                        },
                        new Substance()
                        {
                            Image = "/images/substances/3.png",
                            Name = "Cryo-Lyte",
                            Description = "A supercooled liquid that can be used to stabilize volatile chemical reactions, making it a crucial component in the creation of high-risk drugs.                     "
                        },
                        new Substance()
                        {
                            Image = "/images/substances/4.png",
                            Name = "Neuralite",
                            Description = "A rare mineral that can be used to enhance neural implants and other cybernetic devices, allowing for faster and more precise communication with the user's brain.    "
                        },
                        new Substance()
                        {
                            Image = "/images/substances/5.png",
                            Name = "Hyper-Goo",
                            Description = "A highly elastic, almost indestructible substance that can be used to create drug capsules and implants that can survive extreme conditions and physical trauma.     "
                        }
                    });
                    context.SaveChanges();
                }

                // Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Image = "/images/producers/0.png",
                            Name = "Neuroflux Corporation",
                            Description = "This corporation specializes in producing drugs that enhance neurological function, such as memory enhancers and cognitive stimulants.              "

                        },
                        new Producer()
                        {
                            Image = "/images/producers/1.png",
                            Name = "Synthetix Labs",
                            Description = "A cutting-edge laboratory that creates synthetic drugs that offer powerful mind-altering effects, from hallucinations to heightened senses.         "
                        },
                        new Producer()
                        {
                            Image = "/images/producers/2.png",
                            Name = "Blackout Industries",
                            Description = "A notorious underground drug cartel that deals in highly addictive substances, including mind-wiping agents and memory erasers.                     "
                        },
                        new Producer()
                        {
                            Image = "/images/producers/3.png",
                            Name = "Brainwave Inc.",
                            Description = "A futuristic company that designs and sells brain implants and other neural devices that enhance brain function, but also have dangerous side effects."
                        },
                        new Producer()
                        {
                            Image = "/images/producers/4.png",
                            Name = "Genetix Solutions",
                            Description = "A biotech company that uses genetic engineering to produce designer drugs, customized to each user's specific needs and desires.                      ",
                        }
                    });
                    context.SaveChanges();
                }

                // Drugs
                if (!context.Drugs.Any())
                {
                    context.Drugs.AddRange(new List<Drug>()
                    {
                        new Drug()
                        {
                            Image = "/images/drugs/0.png",
                            Name = "Sativex",
                            Description = "Introducing our newest addition - 'Savitex' - The ultimate cognitive enhancer!",
                            Price = 44.50,
                            PharmacyId = 3,
                            ProducerId = 3,
                            DrugCategory = DrugCategory.Cannabis
                        },
                        new Drug()
                        {
                            Image = "/images/drugs/1.png",
                            Name = "Magic Mushrooms",
                            Description = "Introducing our newest addition - 'Magic Mushrooms' - Unlock the hidden power within",
                            Price = 69.50,
                            PharmacyId = 1,
                            ProducerId = 1,
                            DrugCategory = DrugCategory.Depressants
                        },
                        new Drug()
                        {
                            Image = "/images/drugs/2.png",
                            Name = "Ecstasy",
                            Description = "Introducing our newest addition - 'Ecstasy' - Experience reality like never before!",
                            Price = 57.50,
                            PharmacyId = 4,
                            ProducerId = 4,
                            DrugCategory = DrugCategory.Opioids
                        },
                        new Drug()
                        {
                            Image = "/images/drugs/3.png",
                            Name = "Ketalar",
                            Description = "Introducing our newest addition - 'Ketalar' - Elevate your mind to new heights!",
                            Price = 49.50,
                            PharmacyId = 1,
                            ProducerId = 2,
                            DrugCategory = DrugCategory.Inhalants
                        },
                        new Drug()
                        {
                            Image = "/images/drugs/4.png",
                            Name = "OxyContin",
                            Description = "Introducing our newest addition - 'OxyContin' - Unleash your full potential today!",
                            Price = 22.50,
                            PharmacyId = 1,
                            ProducerId = 3,
                            DrugCategory = DrugCategory.Opioids
                        },
                        new Drug()
                        {
                            Image = "/images/drugs/5.png",
                            Name = "LSD",
                            Description = "Introducing our newest addition - 'LSD' - Upgrade your brain for a brighter future!",
                            Price = 70.50,
                            PharmacyId = 1,
                            ProducerId = 5,
                            DrugCategory = DrugCategory.Cannabis
                        }
                    });
                    context.SaveChanges();
                }

                // Substances & Drugs
                if (!context.Substance_Drugs.Any())
                {
                    context.Substance_Drugs.AddRange(new List<Substance_Drug>()
                    {
                        new Substance_Drug()
                        {
                            SubstanceId = 1,
                            DrugId = 1
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 3,
                            DrugId = 1
                        },

                         new Substance_Drug()
                        {
                            SubstanceId = 1,
                            DrugId = 2
                        },
                         new Substance_Drug()
                        {
                            SubstanceId = 4,
                            DrugId = 2
                        },

                        new Substance_Drug()
                        {
                            SubstanceId = 1,
                            DrugId = 3
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 2,
                            DrugId = 3
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 5,
                            DrugId = 3
                        },

                        new Substance_Drug()
                        {
                            SubstanceId = 2,
                            DrugId = 4
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 3,
                            DrugId = 4
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 4,
                            DrugId = 4
                        },

                        new Substance_Drug()
                        {
                            SubstanceId = 2,
                            DrugId = 5
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 3,
                            DrugId = 5
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 4,
                            DrugId = 5
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 5,
                            DrugId = 5
                        },


                        new Substance_Drug()
                        {
                            SubstanceId = 3,
                            DrugId = 6
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 4,
                            DrugId = 6
                        },
                        new Substance_Drug()
                        {
                            SubstanceId = 5,
                            DrugId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();

                string adminUserEmail = "admin@gmail.com"; // Change to an email chosen by you!

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new User()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@gmail.com"; // Change to an email chosen by you!

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new User()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}

