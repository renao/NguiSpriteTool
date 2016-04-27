using System;
using System.Collections.Generic;
using UnityEngine;

namespace Neo.Unity.Analysis.Formatters {

  public class FormatterResolver {

    private static Dictionary<Type, ComponentInfoFormatter> formatterMap = new Dictionary<Type, ComponentInfoFormatter>();

    public static ComponentInfoFormatter GetFormatterForComponentType(Type componentType) {
      return formatterMap[componentType];
    }

    public static ComponentInfoFormatter GetFormatterForComponent(Component component) {
      return formatterMap[component.GetType()];
    }

    public static void RegisterFormatter(Component componentType, ComponentInfoFormatter formatter) {
      formatterMap[componentType.GetType()] = formatter;
    }
  }
}
