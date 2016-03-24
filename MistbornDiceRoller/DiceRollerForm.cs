// <copyright file="DiceRollerForm.cs" company="Maxwell Game Studio">
//      Maxwell Game Studio. All rights reserved.
// </copyright>
// <author>Martin Kennish</author>

using System;
using System.Windows.Forms;

namespace MistbornDiceRoller
{
    /// <summary>
    /// A simple form that simulates rolling dice in the Mistborn Adventure Game.
    /// </summary>
    public partial class DiceRollerForm : Form
    {
        /// <summary>
        /// Gets or sets the dice repository.
        /// </summary>
        private DiceRepository Repository { get; set; }

        private bool CanRoll { get; set; } = true;

        /// <summary>
        /// Gets or sets the number of the dice in the repository.
        /// </summary>
        public int DiceCount { get; set; } = 6;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceRollerForm"/> class.
        /// </summary>
        public DiceRollerForm()
        {
            InitializeComponent();

            this.SetRepositoryCount();
        }

        /// <summary>
        /// Sets the number of dice in the repository to that of the DiceCount.
        /// </summary>
        private void SetRepositoryCount()
        {
            if (this.Repository == null)
            {
                this.Repository = new DiceRepository(this.DiceCount);
            }
            else
            {
                this.Repository.Count = this.DiceCount;
            }
        }

        /// <summary>
        /// Updates the count of dice in the UI.
        /// </summary>
        private void UpdateUIDiceCount()
        {
            this.txtDiceCount.Text = this.DiceCount.ToString();
        }

        /// <summary>
        /// Validates the dice count. Displays any related information messages
        /// to the user.
        /// </summary>
        /// <returns>Whether the count is valid or not</returns>
        private bool ValidateDiceCount()
        {
            return this.ValidateDiceCount(this.DiceCount);
        }

        /// <summary>
        /// Validates the dice count. Displays any related information messages
        /// to the user.
        /// </summary>
        /// <param name="countValue">The number of dice in the repository</param>
        /// <returns>Whether the count is valid or not</returns>
        private bool ValidateDiceCount(int countValue)
        {
            bool isValid = false;
            if (countValue > 10)
            {
                MessageBox.Show(UIMessages.RepositoryCountTooBig);
            }
            else if (countValue < 2)
            {
                MessageBox.Show(UIMessages.RepositoryCountTooSmall);
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        #region UI Event Handlers

        /// <summary>
        /// Adds a dice to the repository.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event args</param>
        private void BtnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateDiceCount(this.DiceCount + 1))
                {
                    this.txtDiceCount.Text = (this.DiceCount + 1).ToString();
                }
            }
            catch (InvalidOperationException ioe) when (ioe.Message == Exceptions.RepositoryCountAtMax)
            {
                MessageBox.Show(UIMessages.CantAddCountMax);
            }
            catch (InvalidOperationException ioe) when (ioe.Message == Exceptions.RepositoryCountGreaterThanMax)
            {
                this.Repository = new DiceRepository(6);
                MessageBox.Show(UIMessages.RepositoryCountTooBig);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: /n" + ex.Message, "Unexpected Error");
            }
        }

        /// <summary>
        /// Remove a dice from the repository.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event args</param>
        private void BtnDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateDiceCount(this.DiceCount - 1))
                {
                    this.txtDiceCount.Text = (this.DiceCount - 1).ToString();
                }
            }
            catch (InvalidOperationException ioe) when (ioe.Message == Exceptions.RepositoryCountAtMin)
            {
                MessageBox.Show(UIMessages.CantRemoveCountMin);
            }
            catch (InvalidOperationException ioe) when (ioe.Message == Exceptions.RepositoryCountLessThanMin)
            {
                this.Repository = new DiceRepository(6);
                MessageBox.Show(UIMessages.RepositoryCountTooSmall);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: /n" + ex.Message, "Unexpected Error");
            }
        }

        /// <summary>
        /// Handles the dice count text changed event. Sets the number of dice.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event args</param>
        private void TxtDiceCount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiceCount.Text == string.Empty)
            {
                this.CanRoll = false;
                return;
            }

            this.CanRoll = true;


            int value;
            int.TryParse(txtDiceCount.Text, out value);

            if (this.ValidateDiceCount(value))
            {
                this.DiceCount = value;
                this.SetRepositoryCount();
            }

            this.UpdateUIDiceCount();
        }

        /// <summary>
        /// Handles the roll dice event.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event args</param>
        private void BtnRoll_Click(object sender, EventArgs e)
        {
            if (!this.CanRoll)
            {
                if (this.txtDiceCount.Text == string.Empty)
                {
                    MessageBox.Show(UIMessages.MustHaveCount);
                }

                return;
            }

            this.txtResult.Text = this.Repository.Roll().ToString();

            this.txtNudges.Text = this.Repository.GetNudges().ToString();
        }
        #endregion
    }
}
