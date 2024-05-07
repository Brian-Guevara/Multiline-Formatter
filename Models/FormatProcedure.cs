namespace MultiLineStringFormatter.Models;

using System;
using System.ComponentModel;
using System.IO;

public class FormatProcedure : BindableBase
{
    private const String DATATAG = "[[D]]";
    private const String NUMBERTAG= "[[N]]";

    private String output;
    private String input;
    private String format;
    private String delimiter;

    public FormatProcedure()
    {
        this.Input = "Example Text \nTo Test";
        this.Format = "'" + DATATAG +  "'";
        this.Delimiter = ",";
    }

    public String Input
    {
        get => this.input;
        set
        {
            this.input = value;
            this.OnPropertyChanged();
            this.OnPropertyChanged("Preview");
        }
    }

    public String Format
    {
        get => this.format;
        set
        {
            this.format = value;
            this.OnPropertyChanged();
            this.OnPropertyChanged("Preview");
        }
    }

    public String Delimiter
    {
        get => this.delimiter;
        set
        {
            this.delimiter = value;
            this.OnPropertyChanged();
            this.OnPropertyChanged("Preview");

        }
    }

    public String Preview
    {
        get
        {
            try
            {
                String preview = this.Input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[0];
                preview = preview.Trim();
                return this.Format.Replace(DATATAG, preview)
                    .Replace(NUMBERTAG, "1") + this.Delimiter;
            }
            catch
            {
                return "";
            }
        }
    }

    public String Output
    {
        get => this.output;
        set {
            this.output = value;
            this.OnPropertyChanged("Output");
        }
    }

    public void formatInput()
    {
        this.Output = "";
        String [] array = this.Input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int count = 1;
        foreach (String item in array)
        {
            var text = item.Trim();
            if (text == "")
            {
            }
            else
            {
                this.Output += this.Format.Replace(DATATAG, text).Replace(NUMBERTAG, count.ToString()) + this.Delimiter + '\n';
                count++;
            }
        }
        int delimLength = this.Delimiter.Length + 1;
        this.Output = this.Output.Remove(this.Output.Length - delimLength);

    }

    public void addData() => this.Format += DATATAG;

    public void addNumbering() => this.Format += NUMBERTAG;
}
