using System;
using MLToolkit.Forms.SwipeCardView.Core;
using Xamarin.Forms;

namespace SeptemberUIChallenge.Pages
{
    public partial class CardsPage : ContentPage
    {
        public CardsPage()
        {
            InitializeComponent();
        }

        private void OnDragging(object sender, DraggingCardEventArgs args)
        {
            var view = (View)sender;
            var nopeFrame = view.FindByName<Frame>("NopeFrame");
            var likeFrame = view.FindByName<Frame>("LikeFrame");

            switch (args.Position)
            {
                case DraggingCardPosition.Start:
                case DraggingCardPosition.FinishedUnderThreshold:
                case DraggingCardPosition.FinishedOverThreshold:
                    nopeFrame.Opacity = 0;
                    likeFrame.Opacity = 0;
                    nopeButton.Scale = 1;
                    likeButton.Scale = 1;
                    break;

                case DraggingCardPosition.UnderThreshold:
                case DraggingCardPosition.OverThreshold:
                    if (args.Direction == SwipeCardDirection.Left)
                    {
                        nopeFrame.Opacity = 1;
                        nopeButton.Scale = 0.75;
                        likeFrame.Opacity = 0;
                        likeButton.Scale = 1;
                    }
                    else if (args.Direction == SwipeCardDirection.Right)
                    {
                        likeFrame.Opacity = 1;
                        likeButton.Scale = 0.75;
                        nopeFrame.Opacity = 0;
                        nopeButton.Scale = 1;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnNopeClicked(object sender, EventArgs e)
        {
            SwipeCardView.InvokeSwipe(SwipeCardDirection.Left);
        }

        private void OnLikeClicked(object sender, EventArgs e)
        {
            SwipeCardView.InvokeSwipe(SwipeCardDirection.Right);
        }
    }
}