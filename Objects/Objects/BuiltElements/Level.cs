﻿using Objects.Utils;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Objects.BuiltElements
{
  public class Level : Base
  {
    public string name { get; set; }
    public double elevation { get; set; }

    public string units { get; set; }
    //public List<Base> elements { get; set; }

    public Level() { }

    /// <summary>
    /// SchemaBuilder constructor for a Speckle level
    /// </summary>
    /// <param name="name"></param>
    /// <param name="elevation"></param>
    /// <remarks>Assign units when using this constructor due to <paramref name="elevation"/> param</remarks>
    [SchemaInfo("Level", "Creates a Speckle level", "BIM", "Architecture")]
    public Level(string name, double elevation)
    {
      this.name = name;
      this.elevation = elevation;
    }
  }
}

namespace Objects.BuiltElements.Revit
{
  public class RevitLevel : Level
  {
    public bool createView { get; set; }
    public Base parameters { get; set; }
    public string elementId { get; set; }
    public bool referenceOnly { get; set; }

    public RevitLevel() { }

    /// <summary>
    /// SchemaBuilder constructor for a Revit level
    /// </summary>
    /// <param name="name"></param>
    /// <param name="elevation"></param>
    /// <param name="createView"></param>
    /// <param name="parameters"></param>
    /// <remarks>Assign units when using this constructor due to <paramref name="elevation"/> param</remarks>
    [SchemaInfo("RevitLevel", "Creates a new Revit level unless one with the same elevation already exists", "Revit", "Architecture")]
    public RevitLevel(
      [SchemaParamInfo("Level name. NOTE: updating level name is not supported")] string name,
      [SchemaParamInfo("Level elevation. NOTE: updating level elevation is not supported, a new one will be created unless another level at the new elevation already exists.")] double elevation,
      [SchemaParamInfo("If true, it creates an associated view in Revit. NOTE: only used when creating a level for the first time")] bool createView,
      List<Parameter> parameters = null)
    {
      this.name = name;
      this.elevation = elevation;
      this.createView = createView;
      this.parameters = parameters.ToBase();
      this.referenceOnly = false;
    }

    [SchemaInfo("RevitLevel by name", "Gets an existing Revit level by name", "Revit", "Architecture")]
    public RevitLevel(string name)
    {
      this.name = name;
      this.referenceOnly = true;
    }
  }
}
