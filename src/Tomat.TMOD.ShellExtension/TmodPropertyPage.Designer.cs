using System.ComponentModel;

namespace Tomat.TMOD.ShellExtension;

partial class TmodPropertyPage
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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

#region Component Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmlVersion = new System.Windows.Forms.TextBox();
            this.modName = new System.Windows.Forms.TextBox();
            this.modVersion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "tModLoader Version";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mod Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mod Version";
            // 
            // tmlVersion
            // 
            this.tmlVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tmlVersion.Location = new System.Drawing.Point(136, 3);
            this.tmlVersion.Name = "tmlVersion";
            this.tmlVersion.ReadOnly = true;
            this.tmlVersion.Size = new System.Drawing.Size(147, 13);
            this.tmlVersion.TabIndex = 3;
            // 
            // modName
            // 
            this.modName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modName.Location = new System.Drawing.Point(136, 26);
            this.modName.Name = "modName";
            this.modName.ReadOnly = true;
            this.modName.Size = new System.Drawing.Size(147, 13);
            this.modName.TabIndex = 4;
            // 
            // modVersion
            // 
            this.modVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.modVersion.Location = new System.Drawing.Point(136, 49);
            this.modVersion.Name = "modVersion";
            this.modVersion.ReadOnly = true;
            this.modVersion.Size = new System.Drawing.Size(147, 13);
            this.modVersion.TabIndex = 5;
            // 
            // TmodPropertyPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.modVersion);
            this.Controls.Add(this.modName);
            this.Controls.Add(this.tmlVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TmodPropertyPage";
            this.Size = new System.Drawing.Size(286, 304);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    private System.Windows.Forms.TextBox modName;
    private System.Windows.Forms.TextBox modVersion;

    private System.Windows.Forms.TextBox tmlVersion;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
#endregion
}