using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bertuzzi.Xamarin.Forms.Mocks.Models;
using Bertuzzi.Xamarin.Forms.Mocks.Services;
using Bertuzzi.Xamarin.Forms.Mocks.ViewModels;
using ExemploSkeleton.Helpers;
using ExemploSkeleton.Model;

namespace ExemploSkeleton
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<PokemonModel> pokemons;
        private readonly PokemonService _pokemonService;


        public ObservableCollection<PokemonModel> Pokemons
        {
            get { return pokemons; }
            set { SetProperty(ref pokemons, value); }
        }

        public MainViewModel()
        {
            _pokemonService = new PokemonService();

        }

        public override async Task LoadAsync()
        {


            try
            {
                Ocupado = true;

                this.Pokemons = new ObservableCollection<PokemonModel>(new List<PokemonModel> {
                new PokemonModel
                {
                    Name = "x",
                    Id = 1,
                    Ocupado = true
                },
                new PokemonModel
                {
                    Name = "x",
                    Id = 2,
                    Ocupado = true
                },
                new PokemonModel
                {
                    Name = "x",
                    Id = 3,
                    Ocupado = true
                },
                new PokemonModel
                {
                   Name = "x",
                    Id = 4,
                    Ocupado = true
                },
                 new PokemonModel
                {
                   Name = "x",
                    Id = 5,
                    Ocupado = true
                }
            });


                await Task.Delay(2500);


                var pokemonsAPI = await _pokemonService.GetPokemonsAsync(6);
                List<PokemonModel> pokemonsList;

                Pokemons.Clear();

                pokemonsList = pokemonsAPI.Select(ObjectConverter.CastModel<PokemonModel>).ToList();

                for (int i = 0; i < pokemonsList.Count(); i++)
                {
                    pokemonsList[i].Image = _pokemonService.GetImageStreamFromUrl(pokemonsList[i].Sprites.FrontDefault.AbsoluteUri);
                }


                this.Pokemons = new ObservableCollection<PokemonModel>(pokemonsList);


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro", ex.Message);
            }
            finally
            {
                Ocupado = false;
            }

          
        }

        
    }
}
