﻿using AutoMapper;
using Gallery_App.Data;
using Gallery_App.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery_App
{
    public partial class App : Application
    {
        // Инициализация репозитория
        public static PhotoRepository Photos = new PhotoRepository(
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                $"photos.db")
            );

        public static IMapper Mapper { get; set; }

        public App()
        {
            Mapper = CreateMapper();
            // инициализация интерфейса
            InitializeComponent();
            // Инициализация главного экрана и стека навигации
            MainPage = new NavigationPage(new LoginPage());
        }

        /// <summary>
        /// Создание Автомаппера для преобразования сущностей
        /// </summary>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Tables.Photo, Models.Photo>();
                cfg.CreateMap<Models.Photo, Data.Tables.Photo>();
            });

            return config.CreateMapper();
        }

        protected async override void OnStart()
        {
            await Photos.InitDatabase();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
