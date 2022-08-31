using System;
using System.Collections.Generic;
using System.Linq;

namespace SG.Distributeur.Automatique.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
    public class ProduitPrix
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
    }
    public class Ingredient
    {
        public ProduitPrix Produit { get; set; }
        public int Quantite { get; set; }
    }
    public class Recette
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double GetPrix()
        {
            double prix = 0;
            foreach (var Ingredient in Ingredients)
            {
                prix += Ingredient.Produit.Prix * Ingredient.Quantite;
            }
            prix = prix + (prix * 30 / 100);
            return prix;
        }
    }
    public static class distributeurAutomatique
    {
       public static List<ProduitPrix> produits { get; set; }
       public static List<Recette> recettes { get; set; }
       public static void Init()
        {
            produits = new List<ProduitPrix>();
            recettes = new List<Recette>();
            var cafe = new ProduitPrix()
            {
                Id = 1,
                Nom = "Café",
                Prix = 1
            };
            var sucre = new ProduitPrix() { Id = 2, Nom = "Sucre", Prix = 0.1 };
            var creme = new ProduitPrix() { Id = 3, Nom = "Crème", Prix = 0.5 };
            var the = new ProduitPrix() { Id = 4, Nom = "Thé", Prix = 2 };
            var eau = new ProduitPrix() { Id = 5, Nom = "Eau", Prix = 0.2 };
            var chocolat = new ProduitPrix() { Id = 6, Nom = "Chocolat", Prix = 1 };
            var lait = new ProduitPrix() { Id = 7, Nom = "Lait", Prix = 0.4 };
            produits.AddRange(new List<ProduitPrix>()
                                { cafe,
                                 sucre,
                                 creme,
                                 the,
                                 eau,
                                 chocolat,
                                 lait

                                 });
            recettes.AddRange(new List<Recette>()
                                { new Recette()
                                    { Id = 1, Nom = "Expresso",
                                    Ingredients = new List<Ingredient>()
                                                { new Ingredient() { Quantite = 1, Produit = cafe  },
                                                  new Ingredient(){ Quantite =1, Produit = eau  }
                                                }
                                    },
                                new Recette()
                                    { Id = 2, Nom = "Allongé",
                                    Ingredients = new List<Ingredient>()
                                                { new Ingredient() { Quantite = 1, Produit = cafe  },
                                                  new Ingredient(){ Quantite =2, Produit = eau  }
                                                }
                                    },
                                new Recette()
                                    { Id = 3, Nom = "Cappuccino",
                                    Ingredients = new List<Ingredient>()
                                                { new Ingredient() { Quantite = 1, Produit = cafe  },
                                                  new Ingredient(){ Quantite =1, Produit = eau  },
                                                  new Ingredient(){ Quantite =1, Produit = chocolat  },
                                                  new Ingredient(){ Quantite =1, Produit = creme  }
                                                }
                                    },
                                new Recette()
                                    { Id = 4, Nom = "Chocolat",
                                    Ingredients = new List<Ingredient>()
                                                { new Ingredient() { Quantite = 3, Produit = chocolat  },
                                                  new Ingredient(){ Quantite =1, Produit = eau  },
                                                  new Ingredient(){ Quantite =2, Produit = lait  },
                                                  new Ingredient(){ Quantite =1, Produit = sucre  }
                                                }
                                    },
                                new Recette()
                                    { Id = 5, Nom = "Thé",
                                    Ingredients = new List<Ingredient>()
                                                { new Ingredient() { Quantite = 1, Produit = the  },
                                                  new Ingredient(){ Quantite =2, Produit = eau  }
                                                }
                                    } });
            

        }
    }
}
