using Gallery_App.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using Xamarin.Forms;
using Gallery_App.Data;
using System.Collections.ObjectModel;

namespace Gallery_App.Pages
{
    public partial class GalleryPage : ContentPage
    {
        /// <summary>
        /// Колекция фото
        /// </summary>
        public ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();

        /// <summary>
        /// Ссылка на выбранное фото
        /// </summary>
        Photo SelectedPhoto;

        public GalleryPage()
        {
            InitializeComponent();

            //Заполняем список фотографий
            Photos.Add(new Photo("Природа_1", date: "2024-03-13", image: "p1.png"));
            Photos.Add(new Photo("Природа_2", date: "2024-03-13", image: "p2.png"));
            Photos.Add(new Photo("Природа_3", date: "2024-03-13", image: "p3.png"));
            Photos.Add(new Photo("Природа_4", date: "2024-03-13", image: "p4.png"));
            Photos.Add(new Photo("Природа_5", date: "2024-03-13", image: "p5.png"));

            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            // Загрузка данных из базы
            var devicesFromDb = await App.Photos.GetPhotos();
            // Мапим сущности БД в сущности бизнес-логики
            var photoList = App.Mapper.Map<Models.Photo[]>(devicesFromDb);

            // Сохраним
            Photos = new ObservableCollection<Photo>(photoList);
            BindingContext = this;

            base.OnAppearing();
        }

        /// <summary>
        /// Обработчик выбора
        /// </summary>
        private void photoList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // распаковка модели из объекта
            SelectedPhoto = (Photo)e.SelectedItem;
        }

        /// <summary>
        /// Обработчик открывающий выбранное фото
        /// </summary>
        private async void OpenPhoto(object sender, EventArgs e)
        {
            // проверяем, выбрал ли пользователь фото из списка
            if (SelectedPhoto == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите фото!", "OK");
                return;
            }
            await Navigation.PushAsync(new PhotoPage(SelectedPhoto));
        }

        /// <summary>
        /// Обработчик удаления фото
        /// </summary>
        private async void DeletePhoto(object sender, EventArgs e)
        {
            // Получаем сущность базы данных, которую следует удалить (мапим из внутренней сущности, представляющей выбранное устройство)
            var photoToDelete = App.Mapper.Map<Data.Tables.Photo>(SelectedPhoto);
            // Удаляем сущность из бд
            await App.Photos.DeletePhoto(photoToDelete);

            // Обновляем интерфейс
            var photoToRemove = Photos.FirstOrDefault(p => p.Id == photoToDelete.Id);
            Photos.Remove(photoToRemove);

            // проверяем, выбрал ли пользователь фото из списка
            if (SelectedPhoto == null)
            {
                await DisplayAlert(null, $"Пожалуйста, выберите фото!", "OK");
                return;
            }
            else
            {
                // Получаем и "распаковываем" выбранный элемент
                var deviceToRemove = deviceList.SelectedItem as Photo;
                if (deviceToRemove != null)
                {
                    // Уведомляем пользователя
                    bool deleteResult = await DisplayAlert(null, $"Вы уверены, что хотите удалить {deviceToRemove.Name}?", "No", "Yes");

                    if (!deleteResult)
                    {
                        // Удаляем
                        Photos.Remove(deviceToRemove);
                        SelectedPhoto = null;
                        await DisplayAlert(null, $"Картинка '{deviceToRemove.Name}' удалена", "ОК");
                        return;
                    }
                }
            }
        }
    }
}
