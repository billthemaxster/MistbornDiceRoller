// <copyright file="DiceRollerForm.cs" company="Maxwell Game Studio">
//      Maxwell Game Studio. All rights reserved.
// </copyright>
// <author>Martin Kennish</author>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="DiceRollerForm"/> class.
        /// </summary>
        public DiceRollerForm()
        {
            InitializeComponent();

            this.Repository = new DiceRepository(6);
        }

        /// <summary>
        /// Adds a dice to the repository.
        /// </summary>
        /// <param name="sender">the sender</param>
        /// <param name="e">the event args</param>
        private void BtnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Repository.Count == 10)
                {
                    MessageBox.Show(UIMessages.CantAddCountMax);
                }
                else if (this.Repository.Count > 10)
                {
                    MessageBox.Show(UIMessages.RepositoryCountTooBig);
                }
                else if (this.Repository.Count < 2)
                {
                    MessageBox.Show(UIMessages.RepositoryCountTooSmall);
                }
                else
                {
                    this.Repository.Add();
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
            finally
            {
                this.UpdateDiceCount();
            }
        }

        /// <summary>
        /// Updates the count of dice in the UI.
        /// </summary>
        private void UpdateDiceCount()
        {
            this.txtDiceCount.Text = this.Repository.Count.ToString();
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
                if (this.Repository.Count == 2)
                {
                    MessageBox.Show(UIMessages.CantRemoveCountMin);
                }
                else if (this.Repository.Count > 10)
                {
                    MessageBox.Show(UIMessages.RepositoryCountTooBig);
                }
                else if (this.Repository.Count < 2)
                {
                    MessageBox.Show(UIMessages.RepositoryCountTooSmall);
                }
                else
                {
                    this.Repository.Remove();
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
            finally
            {
                this.UpdateDiceCount();
            }
        }
    }
}
