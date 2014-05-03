using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class MySchool 
{
    private readonly SortedSet<Class> classes = new SortedSet<Class>();

    public string Name { get; private set; }

    public MySchool(string name)
    {
        this.Name = name;
    }

    public MySchool AddClass(params Class[] classes)
    {
        foreach (Class _class in classes)
            this.classes.Add(_class);

        return this;
    }

    public MySchool RemoveClass(Class _class)
    {
        this.classes.Remove(_class);

        return this;
    }

    public void Add(Class _class)
    {
        this.AddClass(_class);
    }
    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.AppendLine("# School: " + this.Name);
        foreach (var clas in this.classes)
        {
            info.AppendLine(clas.ToString());
        }

        return info.ToString().TrimEnd();
    }
}