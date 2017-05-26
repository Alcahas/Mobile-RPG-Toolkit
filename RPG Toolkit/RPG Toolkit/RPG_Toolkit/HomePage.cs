using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace RPG_Toolkit
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            StackLayout scrollstack = new StackLayout();
            Button bAdd = new Button //button to add an item 
            {
                Text = "Add",
                HorizontalOptions = LayoutOptions.EndAndExpand //put it on the right
            };
           
            
            Button bRemove = new Button //button to remove an item
            {
                Text = "Remove",
                HorizontalOptions = LayoutOptions.CenterAndExpand //put it on the right
            };
            Picker typePicker = new Picker //picker to hold multiple countable types (tokens, points, etc)
            {
                Title = "Select from this list",    
                HorizontalOptions = LayoutOptions.StartAndExpand //put it on the left
            };
            Entry nameEntry = new Entry //entry field to insert the name of an item
            {
                Placeholder = "Enter name",
                Text = "",
                HorizontalOptions = LayoutOptions.CenterAndExpand //put it on the left
            };




            StackLayout first = new StackLayout //first stack from the top
            {
                Orientation = StackOrientation.Horizontal, //make it put the items horizontally
                Children =
                {
                    nameEntry              
                }
            };
            StackLayout second = new StackLayout //second stack from the top
            {
                Orientation = StackOrientation.Horizontal, //make it put the items horizontally
                Children={
                    typePicker, bAdd
                }
            };
            StackLayout third = new StackLayout //third stack from the top
            {
                Children = {
                    bRemove
                }
            };            
            ScrollView scroll = new ScrollView // the scrollview to hold the created items
            {
                Content = scrollstack
            };
            StackLayout scrollcontainer = new StackLayout //stack containing the scroll
            {
                Children =
                {
                    scroll
                }
            };
            StackLayout topstack = new StackLayout // stack containing the upper elements
            {
                Children =
                {
                    first, second, third
                }
            };
            Frame topframe = new Frame //frame containing the upper elements
            { 
                Content = topstack,
                OutlineColor = Color.Silver
            };         
            StackLayout finalstack = new StackLayout
            {
                Children =
                {
                    topframe, scrollcontainer

                }
            };


            bAdd.Clicked += AddClicked; //event for the Add button click
            void AddClicked(object sender, EventArgs args)
            {
                Label childLabel = new Label
                {
                    Text = nameEntry.Text,
                    FontSize = 26

                };

                scrollstack.Children.Add(new Frame
                {
                    Content = childLabel,
                    OutlineColor = Color.Silver
                });
                    
            }

            bRemove.Clicked += RemoveClicked;
            void RemoveClicked(object sender, EventArgs args)
            {
                if (scrollstack.Children.Count > 0)
                {
                    scrollstack.Children.RemoveAt(scrollstack.Children.Count - 1);
                }
            }


            Content = finalstack;   
        }        
    }
}