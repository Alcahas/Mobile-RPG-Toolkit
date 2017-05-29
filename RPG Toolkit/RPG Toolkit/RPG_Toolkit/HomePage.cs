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
            Color a = Color.White;
        
            Button bAdd = new Button //button to add an item 
            {
                Text = "Add",
             //   HorizontalOptions = LayoutOptions.EndAndExpand //put it on the right
            };         
            Button bRemove = new Button //button to remove an item
            {
                Text = "Remove",
               // HorizontalOptions = LayoutOptions.EndAndExpand //put it on the right
            };
            Picker colorPicker = new Picker //picker to hold multiple countable types (tokens, points, etc)
            {
                Title = "Select from this list",    
                //HorizontalOptions = LayoutOptions.StartAndExpand //put it on the left
            };
            Entry nameEntry = new Entry //entry field to insert the name of an item
            {
                Placeholder = "Enter name",
                Text = "",
                //HorizontalOptions = LayoutOptions.CenterAndExpand //put it in the center
            };
            Picker typePicker = new Picker //picker to hold the type
            { 
              Title = "Choose type",
             // HorizontalOptions = LayoutOptions.StartAndExpand //put it on the left
            };
            Dictionary<string, Color> nameToColor = new Dictionary<string, Color>
            {
                {"White", Color.White},{"Light Gray", Color.LightGray },{"Red", Color.IndianRed}, {"Green", Color.LightGreen}, {"Blue", Color.LightBlue}, {"Yellow", Color.LightYellow}
            };
            foreach (string colorName in nameToColor.Keys)
            {
                colorPicker.Items.Add(colorName);
            }

            string[] types = {"Label", "Stepper"}; //array to hold the type values in the picker
            foreach (string type in types)  //adding the items in the array to the picker
            {
                typePicker.Items.Add(type);
            }

//---------------------------------------------------------------------------------
            StackLayout first = new StackLayout //first stack from the top
            {
                Orientation = StackOrientation.Horizontal, //make it put the items horizontally
                Children =
                {
                    nameEntry, colorPicker              
                }
            };
            StackLayout second = new StackLayout //second stack from the top
            {
              Orientation = StackOrientation.Horizontal, //make it put the items horizontally
                Children={
                    typePicker, bRemove, bAdd
                }
            };
            //StackLayout third = new StackLayout //third stack from the top
            //{
            //    Orientation = StackOrientation.Horizontal, //make it put the items horizontally
            //    Children = {
            //        typePicker, bRemove
            //    }
            //};            
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
                    first, second, //third
                }
            };
            Frame topframe = new Frame //frame containing the upper elements
            { 
                Content = topstack,
                OutlineColor = Color.Silver,
                BackgroundColor = Color.LightGray
            };         
            StackLayout finalstack = new StackLayout
            {
                Children =
                {
                    topframe, scrollcontainer

                }
            };
//-------------------------------------------------------------------------------------------
            colorPicker.SelectedIndexChanged += (sender, args) =>
            {
                if (colorPicker.SelectedIndex == -1)
                {
                    a = Color.White;
                }
                else
                {
                    string colorName = colorPicker.Items[colorPicker.SelectedIndex];
                    a = nameToColor[colorName];
                }
            };

         
            bAdd.Clicked += AddClicked; //event for the Add button click
            void AddClicked(object sender, EventArgs args)
            {
                Label childLabel = new Label
                {
                    Text = nameEntry.Text,
                    FontSize = 26,
                    HorizontalOptions = LayoutOptions.StartAndExpand

                };
                Stepper childStepper = new Stepper
                {
                    Value = 0,
                    Minimum = 0,
                    Maximum = 50,
                    Increment = 1,
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };


                if (typePicker.SelectedIndex == -1)
                {
                    scrollstack.Children.Add(new Frame
                    {
                        Content = childLabel,
                        BackgroundColor = a,
                        OutlineColor = Color.Silver
                    });
                }
                if (typePicker.SelectedIndex == 0)
                {
                    scrollstack.Children.Add(new Frame
                    {
                        Content = childLabel,
                        BackgroundColor = a,
                        OutlineColor = Color.Silver
                    });
                }
                if (typePicker.SelectedIndex == 1)
                {
                    StackLayout stepperLayout = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            childLabel, childStepper
                        }
                    };

                    scrollstack.Children.Add(new Frame
                    {
                        Content = stepperLayout,
                        BackgroundColor = a,
                        OutlineColor = Color.Silver
                    });
                }
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