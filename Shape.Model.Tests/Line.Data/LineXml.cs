using Xml.Generator;

namespace Shape.Model.Tests;

public class LineXml
    : IText
{
    public string Text =>
        $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{Environment.NewLine}" +
        $"<Line>{Environment.NewLine}" +
        $"  <Context>Physic</Context>{Environment.NewLine}" +
        $"  <Color>{Environment.NewLine}" +
        $"    <A>255</A>{Environment.NewLine}" +
        $"    <R>255</R>{Environment.NewLine}" +
        $"    <G>0</G>{Environment.NewLine}" +
        $"    <B>0</B>{Environment.NewLine}" +
        $"    <ScA>1</ScA>{Environment.NewLine}" +
        $"    <ScR>1</ScR>{Environment.NewLine}" +
        $"    <ScG>0</ScG>{Environment.NewLine}" +
        $"    <ScB>0</ScB>{Environment.NewLine}" +
        $"  </Color>{Environment.NewLine}" +
        $"  <MassCenter>{Environment.NewLine}" +
        $"    <X>334</X>{Environment.NewLine}" +
        $"    <Y>680</Y>{Environment.NewLine}" +
        $"  </MassCenter>{Environment.NewLine}" +
        $"  <Velocity>{Environment.NewLine}" +
        $"    <X>0</X>{Environment.NewLine}" +
        $"    <Y>0</Y>{Environment.NewLine}" +
        $"  </Velocity>{Environment.NewLine}" +
        $"  <IsColorFilled>True</IsColorFilled>{Environment.NewLine}" +
        $"  <Mass>10</Mass>{Environment.NewLine}" +
        $"  <RelativeImagePath />{Environment.NewLine}" +
        $"  <SecondPoint>{Environment.NewLine}" +
        $"    <X>299</X>{Environment.NewLine}" +
        $"    <Y>713</Y>{Environment.NewLine}" +
        $"  </SecondPoint>{Environment.NewLine}" +
        $"</Line>";
}