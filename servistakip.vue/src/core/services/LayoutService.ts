import objectPath from "object-path";
import { Actions, Mutations } from "@/store/enums/StoreEnums";
import store from "@/store/";
import { config } from "@/core/helpers/config";

class LayoutService {
  /**
   * @description initialize default layout
   */
  public static init(): void {
    //empty body element classes and attributes
    LayoutService.emptyElementClassesAndAttributes(document.body);

    //setup layout
    LayoutService.initLayoutSettings();
    LayoutService.initToolbarSettings();
    LayoutService.initWidthSettings();

    // init layout components
    LayoutService.initDefaultLayout();
    LayoutService.initToolbar();
    LayoutService.initSidebar();
    LayoutService.initSidebarPanel();
    LayoutService.initHeader();
    LayoutService.initFooter();
    LayoutService.initContent();
  }

  // Init Layout settings
  public static initLayoutSettings(): void {
    const pageWidth = objectPath.get(config.value, "general.pageWidth");
    const layout = objectPath.get(config.value, "general.layout");

    store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
      qualifiedName: "id",
      value: "kt_app_body",
    });

    store.dispatch(Actions.ADD_BODY_CLASSNAME, "app-" + layout);

    store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
      qualifiedName: "data-kt-app-layout",
      value: layout,
    });

    // Light sidebar
    if (layout === "light-sidebar") {
      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "header.default.fixed.desktop",
        value: false,
      });

      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "header.default.fixed.mobile",
        value: false,
      });
    }

    if (layout === "light-sidebar" || layout === "dark-sidebar") {
      if (pageWidth === "default") {
        store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
          property: "header.default.container",
          value: "fluid",
        });

        store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
          property: "toolbar.container",
          value: "fluid",
        });

        store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
          property: "content.container",
          value: "fluid",
        });

        store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
          property: "footer.container",
          value: "fluid",
        });
      }
    }

    if (layout === "light-sidebar" || layout === "dark-sidebar") {
      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "sidebar.display",
        value: true,
      });
    }

    if (layout === "light-header" || layout === "dark-header") {
      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "sidebar.display",
        value: false,
      });

      if (pageWidth === "default") {
        store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
          property: "header.default.container",
          value: "fixed",
        });

        store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
          property: "toolbar.container",
          value: "fixed",
        });

        store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
          property: "content.container",
          value: "fixed",
        });

        store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
          property: "footer.container",
          value: "fixed",
        });
      }
    }
  }

  // Init toolbar settings
  public static initToolbarSettings(): void {
    const defaultContent = objectPath.get(
      config.value,
      "header.default.content"
    );

    if (defaultContent === "pageTitle") {
      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "footer.container",
        value: "fixed",
      });
    }
  }

  // Init page width settings
  public static initWidthSettings(): void {
    const pageWidth = objectPath.get(config.value, "general.pageWidth");
    if (pageWidth !== "default") {
      const container = pageWidth === "fluid" ? "fluid" : "fixed";

      // Set page width
      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "header.default.container",
        value: container,
      });

      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "toolbar.container",
        value: container,
      });

      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "content.container",
        value: container,
      });

      store.commit(Mutations.SET_LAYOUT_CONFIG_PROPERTY, {
        property: "footer.container",
        value: container,
      });
    }
  }

  public static initDefaultLayout(): void {
    if (objectPath.get(config.value, "page.class")) {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "page",
        className: objectPath.get(config.value, "page.class"),
      });
    }

    if (objectPath.get(config.value, "page.container") === "fixed") {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "page-container",
        className: "container-xxl",
      });
    } else if (objectPath.get(config.value, "page.container") === "fluid") {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "page-container",
        className: "container-fluid",
      });
    }

    if (objectPath.get(config.value, "page.containerClass")) {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "page-container",
        className: objectPath.get(config.value, "page.containerClass"),
      });
    }

    if (objectPath.get(config.value, "wrapper.class")) {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "wrapper",
        className: objectPath.get(config.value, "wrapper.class"),
      });
    }

    if (objectPath.get(config.value, "wrapper.container") === "fixed") {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "wrapper-container",
        className: "container-xxl",
      });
    } else if (objectPath.get(config.value, "wrapper.container") === "fluid") {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "wrapper-container",
        className: "container-fluid",
      });
    }

    if (objectPath.get(config.value, "wrapper.containerClass")) {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "wrapper-container",
        className: objectPath.get(config.value, "wrapper.containerClass"),
      });
    }
  }

  public static initToolbar(): void {
    store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
      qualifiedName: "data-kt-app-toolbar-enabled",
      value: "true",
    });

    if (objectPath.get(config.value, "toolbar.class")) {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "toolbar",
        className: objectPath.get(config.value, "toolbar.class"),
      });
    }

    if (objectPath.get(config.value, "toolbar.container") === "fixed") {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "toolbar-container",
        className: "container-xxl",
      });
    } else if (objectPath.get(config.value, "toolbar.container") === "fluid") {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "toolbar-container",
        className: "container-fluid",
      });
    }

    if (objectPath.get(config.value, "toolbar.containerClass")) {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "toolbar-container",
        className: objectPath.get(config.value, "toolbar.containerClass"),
      });
    }

    if (objectPath.get(config.value, "toolbar.fixed.desktop")) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-toolbar-fixed",
        value: "true",
      });
    }

    if (objectPath.get(config.value, "toolbar.fixed.mobile")) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-toolbar-fixed-mobile",
        value: "true",
      });
    }
  }

  public static initSidebar(): void {
    if (!objectPath.get(config.value, "sidebar.display")) {
      return;
    }

    store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
      qualifiedName: "data-kt-app-sidebar-enabled",
      value: "true",
    });

    store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
      qualifiedName: "data-kt-app-sidebar-fixed",
      value: "true",
    });

    if (
      objectPath.get(config.value, "sidebar.default.minimize.desktop.default")
    ) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-sidebar-minimize",
        value: "on",
      });
    }

    if (
      objectPath.get(config.value, "sidebar.default.minimize.desktop.hoverable")
    ) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-sidebar-hoverable",
        value: "true",
      });
    }

    store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
      qualifiedName: "data-kt-app-sidebar-push-header",
      value: "true",
    });

    store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
      qualifiedName: "data-kt-app-sidebar-push-toolbar",
      value: "true",
    });

    store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
      qualifiedName: "data-kt-app-sidebar-push-footer",
      value: "true",
    });

    if (
      objectPath.get(config.value, "sidebar.primary.minimize.desktop.enabled")
    ) {
      if (
        objectPath.get(config.value, "sidebar.primary.minimize.desktop.default")
      ) {
        store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
          qualifiedName: "data-kt-app-sidebar-primary-minimize",
          value: "on",
        });
      }

      if (
        objectPath.get(
          config.value,
          "sidebar.primary.minimize.desktop.hoverable"
        )
      ) {
        store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
          qualifiedName: "data-kt-app-sidebar-primary-hoverable",
          value: "on",
        });
      }

      if (
        objectPath.get(config.value, "sidebar.primary.minimize.mobile.enabled")
      ) {
        if (
          objectPath.get(
            config.value,
            "sidebar.primary.minimize.desktop.default"
          )
        ) {
          store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
            qualifiedName: "data-kt-app-sidebar-primary-minimize-mobile",
            value: "on",
          });
        }

        if (
          objectPath.get(
            config.value,
            "sidebar.primary.minimize.mobile.hoverable"
          )
        ) {
          store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
            qualifiedName: "data-kt-app-sidebar-primary-hoverable-mobile",
            value: "on",
          });
        }
      }

      if (
        objectPath.get(config.value, "sidebar.primary.collapse.desktop.enabled")
      ) {
        if (
          objectPath.get(
            config.value,
            "sidebar.primary.collapse.desktop.default"
          )
        ) {
          store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
            qualifiedName: "data-kt-app-sidebar-primary-collapse",
            value: "on",
          });
        }
      }

      if (
        objectPath.get(config.value, "sidebar.primary.collapse.mobile.enabled")
      ) {
        if (
          objectPath.get(
            config.value,
            "sidebar.primary.collapse.mobile.default"
          )
        ) {
          store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
            qualifiedName: "data-kt-app-sidebar-primary-collapse-mobile",
            value: "on",
          });
        }
      }
    }
  }

  public static initSidebarPanel(): void {
    if (objectPath.get(config.value, "sidebarPanel.class")) {
      store.dispatch(Actions.ADD_CLASSNAME, {
        position: "sidebar-panel",
        className: objectPath.get(config.value, "sidebarPanel.class"),
      });
    }

    if (objectPath.get(config.value, "sidebarPanel.fixed.desktop")) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-sidebar-panel-fixed",
        value: "true",
      });
    } else {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-sidebar-panel-fixed",
        value: "false",
      });
    }

    if (objectPath.get(config.value, "sidebarPanel.minimize.desktop.enabled")) {
      if (
        objectPath.get(config.value, "sidebarPanel.minimize.desktop.default")
      ) {
        store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
          qualifiedName: "data-kt-app-sidebar-panel-minimize",
          value: "on",
        });
      }

      if (
        objectPath.get(config.value, "sidebarPanel.minimize.desktop.hoverable")
      ) {
        store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
          qualifiedName: "data-kt-app-sidebar-panel-hoverable",
          value: "on",
        });
      }

      if (
        objectPath.get(config.value, "sidebarPanel.minimize.mobile.enabled")
      ) {
        if (
          objectPath.get(
            config.value,
            "sidebarPanel.minimize.desktop.hoverable"
          )
        ) {
          store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
            qualifiedName: "data-kt-app-sidebar-panel-hoverable",
            value: "on",
          });
        }
      }
    }
  }

  public static initHeader(): void {
    if (!objectPath.get(config.value, "header.display")) {
      return;
    }

    if (objectPath.get(config.value, "header.default.fixed.desktop")) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-header-fixed",
        value: "true",
      });
    }

    if (objectPath.get(config.value, "header.default.fixed.mobile")) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-header-fixed-mobile",
        value: "true",
      });
    }
  }

  public static initFooter(): void {
    if (objectPath.get(config.value, "footer.fixed.desktop")) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-footer-fixed",
        value: "true",
      });
    }

    if (objectPath.get(config.value, "footer.fixed.mobile")) {
      store.dispatch(Actions.ADD_BODY_ATTRIBUTE, {
        qualifiedName: "data-kt-app-footer-fixed-mobile",
        value: "true",
      });
    }
  }

  // eslint-disable-next-line @typescript-eslint/no-empty-function
  public static initContent(): void {}

  public static emptyElementClassesAndAttributes(element: HTMLElement): void {
    element.className = "";
    for (let i = element.attributes.length; i-- > 0; )
      element.removeAttributeNode(element.attributes[i]);
  }
}

export default LayoutService;
