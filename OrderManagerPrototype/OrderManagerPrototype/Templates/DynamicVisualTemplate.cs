﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrderManagerPrototype.Templates
{
    using Events;
    using Updater;
    using Model;

    public class DynamicVisualTemplate : ITemplate
    {

        #region Assets Declaretions

        WrapPanel wrapPanel;
        Viewbox tableNumberViewbox;
        Label tableNumberLabel;
        Viewbox dateViewbox;
        Label dateLabel;
        Button removeButton;
        Border border;

        #endregion

        //Order event
        public event EventHandler removeEvent;

        #region Constructor

        public DynamicVisualTemplate()
        {
            CurrentHeight = 0;
           // Initialize();
        }

        public DynamicVisualTemplate(Order order)
        {
            this.order = order;
            CurrentHeight = 0;
            Initialize();
        }

        #endregion

        #region Properties

        Order order
        {
            get;
            set;
        }

        #region Assets' Offsets

        int CurrentHeight
        {
            get;
            set;
        }

        int TableNumberWidth
        {
            get { return 90; }
        }

        int TableNumberHeight
        {
            get { return 60; }
        }

        int TotalPriceWidth
        {
            get { return 100; }
        }

        int TotalPriceHeight
        {
            get { return 60; }
        }

        int DateWidth
        {
            get { return BorderWidth - ButtonWidth - TotalPriceWidth - TableNumberWidth - 6; }
        }

        int DateHeight
        {
            get { return 60; }
        }

        int ButtonWidth
        {
            get { return 70; }
        }

        int ButtonHeight
        {
            get { return 60; }
        }

        int SeparatorWidth
        {
            get
            {
                return 2;
            }
        }

        int ProductFieldHeight
        {
            get { return 35; }
        }

        int BorderHeight
        {
            get
            {
                return ((order.Products.Count * (ProductFieldHeight) * Product.Fields) + (order.Products.Count * SeparatorWidth) + ButtonHeight);
            }
        }

        int BorderWidth
        {
            get
            {
                return 450;
            }
        }

        #endregion

        #endregion

        #region Initialize Assets

        void InitializeBorder()
        {
            border = new Border();
            if(order!=null)
            border.Tag = order.OrderID;
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(3);
            border.Width = BorderWidth;
            border.Height = BorderHeight;
            border.VerticalAlignment = VerticalAlignment.Top;
            border.Margin = new Thickness(0, 5, 0, 5);
        }

        void InitializeWrapPanel()
        {
            wrapPanel = new WrapPanel();

			wrapPanel.HorizontalAlignment = HorizontalAlignment.Left;
			wrapPanel.VerticalAlignment = VerticalAlignment.Top;
			wrapPanel.Height=BorderHeight;
			wrapPanel.Width=BorderWidth;
			wrapPanel.Background=Brushes.White;
			
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.EndPoint = new Point(0.5, 1);
            linearGradientBrush.StartPoint = new Point(0.5, 0);

            GradientStop gradientStopBlack = new GradientStop();
            gradientStopBlack.Color = Colors.Black;
            gradientStopBlack.Offset = 0;

            GradientStop gradientStopWhite = new GradientStop();
            gradientStopWhite.Color = Colors.White;
            gradientStopWhite.Offset = 1;

            linearGradientBrush.GradientStops.Add(gradientStopBlack);
            linearGradientBrush.GradientStops.Add(gradientStopWhite);

            wrapPanel.OpacityMask = linearGradientBrush;
        }

        void InitializeTitle(string tableNumber, string date,double totalPrice)
        {

            tableNumberViewbox = new Viewbox();
            tableNumberViewbox.Height = TableNumberHeight;
            tableNumberViewbox.Width = TableNumberWidth;

            tableNumberLabel = new Label();
            tableNumberLabel.FontWeight = FontWeights.Bold;
            tableNumberLabel.Width = TableNumberWidth / 1.5;
            tableNumberLabel.Content = tableNumber + " #" + order.OrderID;
            tableNumberViewbox.Child = tableNumberLabel;
            this.wrapPanel.Children.Add(tableNumberViewbox);

            dateViewbox = new Viewbox();
            dateViewbox.Height = DateHeight;
            dateViewbox.Width = DateWidth;

            dateLabel = new Label();
            dateLabel.Width = DateWidth;
            dateLabel.FontWeight = FontWeights.DemiBold;
            dateLabel.Content = date;
            dateViewbox.Child = dateLabel;
            this.wrapPanel.Children.Add(dateViewbox);

            Viewbox priceViewBox = new Viewbox();
            priceViewBox.Height = TotalPriceHeight;
            priceViewBox.Width = TotalPriceWidth;

            Label priceLabel = new Label();
            priceLabel.Width = TotalPriceWidth/1.5;
            priceLabel.FontWeight = FontWeights.DemiBold;
            priceLabel.Content = totalPrice + " €";
            priceViewBox.Child = priceLabel;
            this.wrapPanel.Children.Add(priceViewBox);

            InitializeRemoveButton();

            CurrentHeight = DateHeight;

            AddLineSeparator(2);
        }

        void AddLineSeparator(int height)
        {
            Rectangle rect = new Rectangle();
            rect.Stroke = Brushes.Black;
            rect.Fill = Brushes.Black;
            rect.Width = BorderWidth;
            rect.Height = height;
            CurrentHeight += SeparatorWidth;
            this.wrapPanel.Children.Add(rect);
        }

        void InitializeViewboxesAndLabels(Product product)
        {
            //Name
            Viewbox productViewbox = new Viewbox();
            productViewbox.Height = ProductFieldHeight;
            productViewbox.Width = BorderWidth;
            CurrentHeight += ProductFieldHeight;

            Label productNameLabel = new Label();
            productNameLabel.Width = product.Title.Length * 10 + 1;
            productNameLabel.FontWeight = FontWeights.Bold;
            productNameLabel.Content = product.Title;
            productViewbox.Child = productNameLabel;
            this.wrapPanel.Children.Add(productViewbox);

            //Price
            Viewbox priceViewbox = new Viewbox();
            priceViewbox.Height = ProductFieldHeight;
            priceViewbox.Width = BorderWidth;
            CurrentHeight += ProductFieldHeight;
            Label priceLabel = new Label();
            //priceLabel.Content = Math.Round(product.Price * product.Quantity, 2) + " €";
            priceLabel.Content = Math.Round(product.Price, 2) + " €";
            priceLabel.Width = BorderWidth / 4;

            priceViewbox.Child = priceLabel;
            this.wrapPanel.Children.Add(priceViewbox);

            //Notes
            Viewbox notesViewbox = new Viewbox();
            notesViewbox.Height = ProductFieldHeight;
            notesViewbox.Width = product.Notes.Length * 50 + 1;

            Label notesLabel = new Label();
            notesLabel.Content = product.Notes;

            notesLabel.Width = product.Notes.Length * 10 + 1;
            notesLabel.Height = ProductFieldHeight;
            CurrentHeight += ProductFieldHeight;
            notesViewbox.Child = notesLabel;
            this.wrapPanel.Children.Add(notesViewbox);
            AddLineSeparator(1);
        }

        void InitializeRemoveButton()
        {
            removeButton = new Button();
            removeButton.Content = "X";
            removeButton.Width = ButtonWidth;
            removeButton.RenderTransformOrigin = new Point(0.613, -0.2);
            removeButton.HorizontalAlignment = HorizontalAlignment.Right;
            removeButton.VerticalAlignment = VerticalAlignment.Top;
            removeButton.Height = ButtonHeight;
            removeButton.BorderBrush = Brushes.White;
            removeButton.Foreground = Brushes.White;
            removeButton.Background = Brushes.Black;
            removeButton.FontSize = 26.667;

            removeButton.Click += (sender, args) =>
                       {
                           if (removeEvent != null)
                           {
                               removeEvent(this, new OrderEventArgs(this));
                           }
                       };

            this.wrapPanel.Children.Add(removeButton);
        }

        #endregion

        public void Initialize()
        {
            InitializeBorder();
            InitializeWrapPanel();
            InitializeTitle(order.TableNumber,order.DateTime,order.TotalPrice);

            foreach (Product product in order.Products)
                InitializeViewboxesAndLabels(product);     

            this.border.Child=wrapPanel;
        }

        #region Get Template Property

        public Border OrderTemplate
        {
            get
            {
                return border;
            }
            set
            {
                border = value;
            }
        }

        public int ID
        {
            get
            {
                return (int)border.Tag;
            }
        }


        #endregion
    }
}