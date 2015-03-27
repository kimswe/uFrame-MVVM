﻿using System;
using UnityEngine;
using System.Collections;
using Invert.Core.GraphDesigner;
using Invert.uFrame.MVVM;

public class HelloWorldTutorial : uFrameMVVMPage
{
    public override string Name
    {
        get { return "Hello World Tutorial"; }
    }

    public override Type ParentPage
    {
        get { return typeof(GettingStarted); }
    }

    public override void GetContent(IDocumentationBuilder builder)
    {
        base.GetContent(builder);
        builder.BeginTutorial(this.Name);
        DoTutorial(builder);
        DoFinalStep(builder);
        builder.EndTutorial();
    }

    protected virtual void DoTutorial(IDocumentationBuilder builder)
    {
        var project = DoCreateNewProjectStep(builder);

        if (project == null) return;

        var graph = DoGraphStep<MVVMGraph>(builder,
            _ => _.ImageByUrl("http://i.imgur.com/2WrQCzv.png"));
        
        if (graph == null) return;
        
        var subsystemNode = DoNamedNodeStep<SubsystemNode>(builder, "Core", null,
            _ => { _.ImageByUrl("http://i.imgur.com/yW7CmVr.png"); });

        if (subsystemNode == null) return;


        var sceneManagerNode = DoNamedNodeStep<SceneManagerNode>(
            builder,
            "MainScene",
            null,
            _ => _.ImageByUrl("http://i.imgur.com/v8GehAF.png")
            );

        if (sceneManagerNode == null) return;


        DoCreateConnectionStep(
            builder,
            subsystemNode.ExportOutputSlot,
            sceneManagerNode.SubsystemInputSlot,
            _ => _.ImageByUrl("http://i.imgur.com/q3kchHi.png")
        );

        var elementNode = DoNamedNodeStep<ElementNode>(
            builder,
            "GameContext",
            subsystemNode,
            _ => _.ImageByUrl("http://i.imgur.com/4ioW9EX.png")
            );

        if (elementNode == null) return;

        var firstNameProperty = DoNamedItemStep<PropertiesChildItem>(builder, "FirstName", elementNode,
            "a property", _ => _.ImageByUrl("http://i.imgur.com/qn5GZ6b.png"));

        if (firstNameProperty == null) return;

        var changeNameCommand = DoNamedItemStep<CommandsChildItem>(builder, "ChangeName", elementNode, "a command",
            _ => { _.ImageByUrl("http://i.imgur.com/4lxeQru.png"); });

        if (changeNameCommand == null) return;

        var viewNode = DoNamedNodeStep<ViewNode>(builder, "GameContextView", elementNode,
            _ => { _.ImageByUrl("http://i.imgur.com/g6cs4tw.png"); });
        if (viewNode == null) return;

        DoCreateConnectionStep(builder, elementNode, viewNode.ElementInputSlot,
            _ => { _.ImageByUrl("http://i.imgur.com/W7ZTGjU.png"); });

        var binding = DoNamedItemStep<BindingsReference>(builder, "FirstName Changed", viewNode,
            "a binding by choosing the item", _ => { });
        if (binding == null) return;

        builder.ShowTutorialStep(SaveAndCompile(viewNode));


        builder.ShowTutorialStep(CreateSceneCommand(sceneManagerNode),
            _ => { _.ImageByUrl("http://i.imgur.com/9QSXAPH.png"); });


        var viewBase = EnsureComponentInSceneStep<ViewBase>(builder, viewNode, _ =>
        {
            _.ImageByUrl("http://i.imgur.com/JTIeWL8.png");
            _.ImageByUrl("http://i.imgur.com/1CTHigb.png");
        });

        builder.ShowTutorialStep(
            new TutorialStep("Ctrl+Click on the {0} Node.  This will open up the controller code.",
                () => null),
            _ => { _.ImageByUrl("http://i.imgur.com/jE47U8m.png"); });


        builder.ShowTutorialStep(
            new TutorialStep(
                "Ctrl+Click on the {0} Node.  This will open up the controller code.",
                () => EnsureCodeInEditableFile(elementNode, "Controller.cs", ".FirstName")),
            _ => { _.ImageByUrl("http://i.imgur.com/jE47U8m.png"); }
            );

    }

    protected virtual void DoFinalStep(IDocumentationBuilder builder)
    {
        builder.ShowTutorialStep(
            new TutorialStep(
                "Congratulations",
                () => "You're awesome!"),
            _ =>
            {
                _.Paragraph(
                    "Run the game, click on the view, and then click on the 'ChangeName' button. You'll see the FirstName property showing 'Hello World'.");
                _.ImageByUrl("http://i.imgur.com/dfkOvX1.png");
            }
            );
    }
}

public class ViewBindingsTutorial : HelloWorldTutorial
{
    public override string Name
    {
        get { return "View Bindings Tutorial"; }
    }

    public override decimal Order
    {
        get { return 2; }
    }

    protected override void DoTutorial(IDocumentationBuilder builder)
    {
        base.DoTutorial(builder);

    }
}

public class GettingStarted : uFrameMVVMPage
{
    public override string Name
    {
        get { return "Getting Started"; }
    }

    public override decimal Order
    {
        get { return -2; }
    }
}

public class ChangeLogPage : uFrameMVVMPage
{
    private TextAsset _changeLog;
    private string[] _lines;

    public TextAsset ChangeLog
    {
        get { return _changeLog ?? (_changeLog = Resources.Load("uFrameReadme", typeof(TextAsset)) as TextAsset); }
        set { _changeLog = value; }
    }

    public string[] Lines
    {
        get
        {
            return _lines ?? (_lines = ChangeLog.text.Split(Environment.NewLine.ToCharArray()));
        }
    }
    public override string Name
    {
        get { return "Change Log"; }
        set { base.Name = value; }
    }

    public override decimal Order
    {
        get { return -4; }
    }

    public override void GetContent(IDocumentationBuilder _)
    {
        base.GetContent(_);
        foreach (var line in Lines)
        {
            _.Paragraph(line);
        }
    }
}