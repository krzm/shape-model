using Xml.Generator;

namespace Shape.Model.Tests;

public class ShapesDefaultSchema
    : IText
{
    const string HttpAddress1 = "\"http://www.w3.org/2001/XMLSchema-instance\"";

    const string HttpAddress2 = "\"http://www.w3.org/2001/XMLSchema\"";

    public string Text =>
        $"<?xml version=\"1.0\" encoding=\"utf-8\"?>{MyConst.NewLine}" +
        $"<ShapeContext>{MyConst.NewLine}" +
        $"  <Circle>{MyConst.NewLine}" +
        $"    <TextFlag>black</TextFlag>{MyConst.NewLine}" +
        $"    <Context>Physic</Context>{MyConst.NewLine}" +
        $"    <Color>{MyConst.NewLine}" +
        $"      <A>0</A>{MyConst.NewLine}" +
        $"      <R>0</R>{MyConst.NewLine}" +
        $"      <G>0</G>{MyConst.NewLine}" +
        $"      <B>0</B>{MyConst.NewLine}" +
        $"      <ScA>0</ScA>{MyConst.NewLine}" +
        $"      <ScR>0</ScR>{MyConst.NewLine}" +
        $"      <ScG>0</ScG>{MyConst.NewLine}" +
        $"      <ScB>0</ScB>{MyConst.NewLine}" +
        $"    </Color>{MyConst.NewLine}" +
        $"    <MassCenter>{MyConst.NewLine}" +
        $"      <X>10</X>{MyConst.NewLine}" +
        $"      <Y>10</Y>{MyConst.NewLine}" +
        $"    </MassCenter>{MyConst.NewLine}" +
        $"    <Velocity>{MyConst.NewLine}" +
        $"      <X>0</X>{MyConst.NewLine}" +
        $"      <Y>0</Y>{MyConst.NewLine}" +
        $"    </Velocity>{MyConst.NewLine}" +
        $"    <IsColorFilled>True</IsColorFilled>{MyConst.NewLine}" +
        $"    <Mass>10</Mass>{MyConst.NewLine}" +
        $@"    <RelativeImagePath>Images\ball8.bmp</RelativeImagePath>{MyConst.NewLine}" +
        $"    <Radius>20</Radius>{MyConst.NewLine}" +
        $"  </Circle>{MyConst.NewLine}" +
        $"  <Line>{MyConst.NewLine}" +
        $"    <Context>Physic</Context>{MyConst.NewLine}" +
        $"    <Color>{MyConst.NewLine}" +
        $"      <A>255</A>{MyConst.NewLine}" +
        $"      <R>255</R>{MyConst.NewLine}" +
        $"      <G>0</G>{MyConst.NewLine}" +
        $"      <B>0</B>{MyConst.NewLine}" +
        $"      <ScA>1</ScA>{MyConst.NewLine}" +
        $"      <ScR>1</ScR>{MyConst.NewLine}" +
        $"      <ScG>0</ScG>{MyConst.NewLine}" +
        $"      <ScB>0</ScB>{MyConst.NewLine}" +
        $"    </Color>{MyConst.NewLine}" +
        $"    <MassCenter>{MyConst.NewLine}" +
        $"      <X>334</X>{MyConst.NewLine}" +
        $"      <Y>680</Y>{MyConst.NewLine}" +
        $"    </MassCenter>{MyConst.NewLine}" +
        $"    <Velocity>{MyConst.NewLine}" +
        $"      <X>0</X>{MyConst.NewLine}" +
        $"      <Y>0</Y>{MyConst.NewLine}" +
        $"    </Velocity>{MyConst.NewLine}" +
        $"    <IsColorFilled>True</IsColorFilled>{MyConst.NewLine}" +
        $"    <Mass>10</Mass>{MyConst.NewLine}" +
        $"    <RelativeImagePath />{MyConst.NewLine}" +
        $"    <SecondPoint>{MyConst.NewLine}" +
        $"      <X>299</X>{MyConst.NewLine}" +
        $"      <Y>713</Y>{MyConst.NewLine}" +
        $"    </SecondPoint>{MyConst.NewLine}" +
        $"  </Line>{MyConst.NewLine}" +
        $"  <Rectangle>{MyConst.NewLine}" +
        $"    <Context>Graphic</Context>{MyConst.NewLine}" +
        $"    <Color>{MyConst.NewLine}" +
        $"      <A>255</A>{MyConst.NewLine}" +
        $"      <R>255</R>{MyConst.NewLine}" +
        $"      <G>0</G>{MyConst.NewLine}" +
        $"      <B>0</B>{MyConst.NewLine}" +
        $"      <ScA>1</ScA>{MyConst.NewLine}" +
        $"      <ScR>1</ScR>{MyConst.NewLine}" +
        $"      <ScG>0</ScG>{MyConst.NewLine}" +
        $"      <ScB>0</ScB>{MyConst.NewLine}" +
        $"    </Color>{MyConst.NewLine}" +
        $"    <MassCenter>{MyConst.NewLine}" +
        $"      <X>242</X>{MyConst.NewLine}" +
        $"      <Y>16</Y>{MyConst.NewLine}" +
        $"    </MassCenter>{MyConst.NewLine}" +
        $"    <Velocity>{MyConst.NewLine}" +
        $"      <X>0</X>{MyConst.NewLine}" +
        $"      <Y>0</Y>{MyConst.NewLine}" +
        $"    </Velocity>{MyConst.NewLine}" +
        $"    <IsColorFilled>True</IsColorFilled>{MyConst.NewLine}" +
        $"    <Mass>10</Mass>{MyConst.NewLine}" +
        $@"    <RelativeImagePath>Images\table.jpg</RelativeImagePath>{MyConst.NewLine}" +
        $"    <Size>{MyConst.NewLine}" +
        $"      <Width>1440</Width>{MyConst.NewLine}" +
        $"      <Height>819</Height>{MyConst.NewLine}" +
        $"    </Size>{MyConst.NewLine}" +
        $"  </Rectangle>{MyConst.NewLine}" +
        $"</ShapeContext>";
}