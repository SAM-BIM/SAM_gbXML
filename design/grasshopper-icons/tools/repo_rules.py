"""Repository-specific classification decisions for SAM_gbXML (the only non-shared tool file).

OVERRIDES     : component display name -> (object glyph, op, extra)   extra: None | "plural" | "library" | note
PARAM_OBJECTS : param type key (Goo<X>Param class or typeof(X) name) -> glyph | (glyph, container, plural)
OBJECTS/VERBS : extra noun/verb rules tried before the shared ones (same shapes as SAM's OBJECTS/VERBS)
"""
OVERRIDES = {"FromgbXML": ("model", "import", None), "TogbXML": ("model", "export", None)}
PARAM_OBJECTS = {}
OBJECTS = []
VERBS = []
