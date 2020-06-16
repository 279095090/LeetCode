using System;

[System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
sealed class SubjectAttrubute : System.Attribute
{
    // See the attribute guidelines at
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    readonly string positionalString;

    // This is a positional argument
    public SubjectAttrubute(int no, string desc = null, string url = null, string[] tags = null)
    {
        this.No = no;

        this.Desc = desc;

        this.Tags = tags;

        this.Url = url;
    }

    public string Desc { get; private set; }
    public int No { get; private set; }

    public string Url { get; private set; }

    public string[] Tags { get; private set; }

}