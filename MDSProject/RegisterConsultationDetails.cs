﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSProject
{
    public partial class RegisterConsultationDetails : Form
    {
        HealthITDBContainer1 container = new HealthITDBContainer1();
        public RegisterConsultationDetails()
        {
            InitializeComponent();
            lb_appointments.Items.Clear();
            lb_appointments.Items.AddRange(container.AppointmentSet.ToArray<Appointment>());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                btn_pesquisar.Enabled = true;
            }
            else
            {
                btn_pesquisar.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lb_appointments.SelectedItem != null)
            {
                Appointment appointment = (Appointment)lb_appointments.SelectedItem;
                txt_diagnosis.Enabled = true;
                txt_symptoms.Enabled = true;
                lbl_date.Text = appointment.Date.ToString();
                lbl_doctor.Text = appointment.Doctor.ToString();
                lbl_hour.Text = appointment.Hour.ToString();
                lbl_patient.Text = appointment.PatientName.ToString();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string myString = textBox1.Text;
            int index = lb_appointments.FindString(myString, -1);
            if (index != -1)
            {
                lb_appointments.SetSelected(index, true);
                MessageBox.Show("Found the item \"" + myString + "\" at index: " + index);
            }
            else
                MessageBox.Show("Item not found.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}