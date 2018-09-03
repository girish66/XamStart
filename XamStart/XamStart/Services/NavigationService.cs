﻿using System;
using System.Threading.Tasks;
using XamStart.Helpers;
using XamStart.Interfaces;
using Unity;
using Xamarin.Forms;
using XamStart.Views;

namespace XamStart.Services
{
    public class NavigationService : INavigationService
    {
        ICurrentlySelectedFactory currentlySelectedFactory;

        public NavigationService (ICurrentlySelectedFactory currentlySelectedFactory) {
            this.currentlySelectedFactory = currentlySelectedFactory;
        }
        /// <summary>
        /// Used when you want to change to one of the pages specified in your side menu
        /// </summary>
        /// <param name="type">Type.</param>
        public void MDDetailPageNavigate(Type type){
            currentlySelectedFactory.DesiredMasterDetailDetailPage = type;
            var page = (Page)ViewModelLocator.Container.Resolve<IMDPage>();
            App.Current.MainPage = page;
        }
        /// <summary>
        /// Use this method for normal navigation
        /// </summary>
        /// <returns>The to child page.</returns>
        /// <param name="type">Type.</param>
        public async Task NavigateToChildPage(Type type)
        {
            var page = (Page)ViewModelLocator.Container.Resolve(type);
            var mdpage = (MasterDetailPage)ViewModelLocator.Container.Resolve<IMDPage>();
            await mdpage.Detail.Navigation.PushAsync(page);
        }
        /// <summary>
        /// Pretty much only used when navigating from the Login page (which has no side menu) to the main MasterDetailPage
        /// </summary>
        /// <param name="type">Type.</param>
        public void RootNavigate(Type type){
            var page = (Page)ViewModelLocator.Container.Resolve(type);
            App.Current.MainPage = page;
        }
    }
}
