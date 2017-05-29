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
            StackLayout scrollstack = new StackLayout(); //scrollstack template
            Color a = Color.White; //default color
//--------------------------------------------------------------------------------
//------------------------------Visual elements------------------------------------
//-----------------------------------------------------------------------------------        

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

            Dictionary<string, Color> nameToColor = new Dictionary<string, Color> //dictionary to hold all the key-value color pairings in the picker
            {
                {"White", Color.White},{"Light Gray", Color.LightGray },{"Red", Color.IndianRed}, {"Green", Color.LightGreen}, {"Blue", Color.LightBlue}, {"Yellow", Color.LightYellow}
            };
            foreach (string colorName in nameToColor.Keys) //populating the picker with the dictionary items above
            {
                colorPicker.Items.Add(colorName);
            }

            string[] types = {"Label", "Stepper"}; //array to hold the type values in the picker
            foreach (string type in types)  //adding the items in the array to the picker
            {
                typePicker.Items.Add(type);
            }

//---------------------------------------------------------------------------------
//------------------------------Containers------------------------------------------
//-----------------------------------------------------------------------------------
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
                    first, second
                }
            };

            Frame topframe = new Frame //frame containing the upper elements
            { 
                Content = topstack,
                OutlineColor = Color.Silver,
                BackgroundColor = Color.LightGray
            };         

            

//---------------------------------------------------------------------------------
//------------------------------Event handlers--------------------------------------
//-----------------------------------------------------------------------------------
            colorPicker.SelectedIndexChanged += (sender, args) => //event to handle the index change (selection) of the color Picker
            {
                if (colorPicker.SelectedIndex == -1) //default value
                {
                    a = Color.White; 
                }
                else
                {
                    string colorName = colorPicker.Items[colorPicker.SelectedIndex]; //setting the value using the dictionary
                    a = nameToColor[colorName];
                }
            };

         
            bAdd.Clicked += AddClicked; //event for the Add button click
            void AddClicked(object sender, EventArgs args)
            {
                string savedName = nameEntry.Text; // saving the data in the Entry box
                Label childLabel = new Label //simple label also used as default
                {
                    Text = savedName,
                    FontSize = 26,
                    HorizontalOptions = LayoutOptions.StartAndExpand

                };

                Stepper childStepper = new Stepper //the stepper constructor, object is made by pressing the Add button after choosing Stepper from the picker
                {
                    Value = 0,
                    Minimum = 0,
                    Maximum = 50,
                    Increment = 1,
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };

                Label stepperLabel = new Label //label to be used with its corresponding stepper
                {
                    Text = String.Format("{0}: {1}", savedName, childStepper.Value), //setting the value of the label to the correct format and current stepper value
                    FontSize = 26,
                    HorizontalOptions = LayoutOptions.StartAndExpand
                };

                childStepper.ValueChanged += OnStepperValueChanged;
                void OnStepperValueChanged (object Sender, ValueChangedEventArgs e)
                {
                    stepperLabel.Text = String.Format("{0}: {1}", savedName,childStepper.Value);
                }
                if ((typePicker.SelectedIndex == -1) || (typePicker.SelectedIndex == 0)) //adding the simple label for the default picker value and label option
                {
                    scrollstack.Children.Add(new Frame 
                    {
                        Content = childLabel,
                        BackgroundColor = a,
                        OutlineColor = Color.Silver
                    });
                }                               
                if (typePicker.SelectedIndex == 1) //what to do when the second (index 1) option of the picker is chosen
                {
                    StackLayout stepperLayout = new StackLayout()
                    {                        
                        Children =
                        {
                            stepperLabel, childStepper
                        }
                    };

                    scrollstack.Children.Add(new Frame //adding the actual frame with the label and stepper, in this case
                    {
                        Content = stepperLayout,
                        BackgroundColor = a,
                        OutlineColor = Color.Silver
                    });
                }
            }

            bRemove.Clicked += RemoveClicked; //button to remove the downmost element in the scrolling stack
            void RemoveClicked(object sender, EventArgs args)
            {
                if (scrollstack.Children.Count > 0) //check to see if there are any elements in the scrolling stack
                {
                    scrollstack.Children.RemoveAt(scrollstack.Children.Count - 1); //removing the last (lowest) element of the scrollingstack
                }
            }

            
            
//---------------------------------------------------------------------------------
//------------------------------Populating the final stack--------------------------
//-----------------------------------------------------------------------------------
            Content = new StackLayout()         
            {
                Children =
                {
                    topframe, scrollcontainer

                }
            };
        }        
    }
}