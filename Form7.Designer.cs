namespace ProgramForGarazhFinal
{
    partial class Form7
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label boxLabel;
            System.Windows.Forms.Label phoneLabel;
            System.Windows.Forms.Label deptLabel;
            this.garazhDataSet = new ProgramForGarazhFinal.GarazhDataSet();
            this.peopleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.peopleTableAdapter = new ProgramForGarazhFinal.GarazhDataSetTableAdapters.PeopleTableAdapter();
            this.tableAdapterManager = new ProgramForGarazhFinal.GarazhDataSetTableAdapters.TableAdapterManager();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.boxTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.deptTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            nameLabel = new System.Windows.Forms.Label();
            boxLabel = new System.Windows.Forms.Label();
            phoneLabel = new System.Windows.Forms.Label();
            deptLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.garazhDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(63, 54);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(83, 32);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "ФИО:";
            // 
            // boxLabel
            // 
            boxLabel.AutoSize = true;
            boxLabel.Location = new System.Drawing.Point(64, 122);
            boxLabel.Name = "boxLabel";
            boxLabel.Size = new System.Drawing.Size(82, 32);
            boxLabel.TabIndex = 2;
            boxLabel.Text = "Бокс:";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new System.Drawing.Point(12, 183);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(134, 32);
            phoneLabel.TabIndex = 4;
            phoneLabel.Text = "Телефон:";
            // 
            // deptLabel
            // 
            deptLabel.AutoSize = true;
            deptLabel.Location = new System.Drawing.Point(65, 246);
            deptLabel.Name = "deptLabel";
            deptLabel.Size = new System.Drawing.Size(81, 32);
            deptLabel.TabIndex = 6;
            deptLabel.Text = "Долг:";
            // 
            // garazhDataSet
            // 
            this.garazhDataSet.DataSetName = "GarazhDataSet";
            this.garazhDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // peopleBindingSource
            // 
            this.peopleBindingSource.DataMember = "People";
            this.peopleBindingSource.DataSource = this.garazhDataSet;
            // 
            // peopleTableAdapter
            // 
            this.peopleTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.JournalTableAdapter = null;
            this.tableAdapterManager.PeopleTableAdapter = this.peopleTableAdapter;
            this.tableAdapterManager.UpdateOrder = ProgramForGarazhFinal.GarazhDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peopleBindingSource, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(152, 51);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(351, 39);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // boxTextBox
            // 
            this.boxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peopleBindingSource, "Box", true));
            this.boxTextBox.Location = new System.Drawing.Point(152, 119);
            this.boxTextBox.Name = "boxTextBox";
            this.boxTextBox.Size = new System.Drawing.Size(100, 39);
            this.boxTextBox.TabIndex = 3;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peopleBindingSource, "Phone", true));
            this.phoneTextBox.Location = new System.Drawing.Point(152, 180);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(201, 39);
            this.phoneTextBox.TabIndex = 5;
            // 
            // deptTextBox
            // 
            this.deptTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.peopleBindingSource, "Dept", true));
            this.deptTextBox.Location = new System.Drawing.Point(152, 243);
            this.deptTextBox.Name = "deptTextBox";
            this.deptTextBox.Size = new System.Drawing.Size(100, 39);
            this.deptTextBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 59);
            this.button1.TabIndex = 8;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(deptLabel);
            this.Controls.Add(this.deptTextBox);
            this.Controls.Add(phoneLabel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(boxLabel);
            this.Controls.Add(this.boxTextBox);
            this.Controls.Add(nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.garazhDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GarazhDataSet garazhDataSet;
        private System.Windows.Forms.BindingSource peopleBindingSource;
        private GarazhDataSetTableAdapters.PeopleTableAdapter peopleTableAdapter;
        private GarazhDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox boxTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox deptTextBox;
        private System.Windows.Forms.Button button1;
    }
}