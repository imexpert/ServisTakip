import { computed } from "vue";
import store from "@/store/index";

/**
 * Returns layout config
 * @returns {object}
 */
export const config = computed(() => {
  return store.getters.layoutConfig();
});

/**
 * Returns theme mode
 * @returns {string}
 */
export const themeMode = computed(() => {
  return store.getters.layoutConfig("general.mode");
});

/**
 * Set the sidebar display
 * @returns {boolean}
 */
export const displaySidebar = computed(() => {
  return store.getters.layoutConfig("sidebar.display");
});

/**
 * Sidebar toggle
 * @returns {boolean}
 */
export const sidebarToggleDisplay = computed(() => {
  return store.getters.layoutConfig("sidebar.default.minimize.desktop.enabled");
});

/**
 * Check if footer container is fluid
 * @returns {boolean}
 */
export const footerWidthFluid = computed(() => {
  return store.getters.layoutConfig("footer.container") === "fluid";
});

/**
 * Footer display
 * @returns {boolean}
 */
export const footerDisplay = computed(() => {
  return store.getters.layoutConfig("footer.display");
});

/**
 * Check if header container is fluid
 * @returns {boolean}
 */
export const headerWidthFluid = computed(() => {
  return store.getters.layoutConfig("header.default.container") === "fluid";
});

/**
 * Header display
 * @returns {boolean}
 */
export const headerDisplay = computed(() => {
  return store.getters.layoutConfig("header.display");
});

/**
 * Returns header left part type
 * @returns {string}
 */
export const headerLeft = computed(() => {
  return store.getters.layoutConfig("header.left");
});

/**
 * Sidebar display
 * @returns {boolean}
 */
export const sidebarDisplay = computed(() => {
  return store.getters.layoutConfig("sidebar.display");
});

/**
 * Layout type
 * @returns {string}
 */
export const layout = computed(() => {
  return store.getters.layoutConfig("general.layout");
});

/**
 * Check if toolbar width is fluid
 * @returns {boolean}
 */
export const toolbarWidthFluid = computed(() => {
  return store.getters.layoutConfig("toolbar.container") === "fluid";
});

/**
 * Set the toolbar display
 * @returns {boolean}
 */
export const toolbarDisplay = computed(() => {
  return store.getters.layoutConfig("toolbar.display");
});

/**
 * Check if container width is fluid
 * @returns {boolean}
 */
export const contentWidthFluid = computed(() => {
  return store.getters.layoutConfig("content.container") === "fluid";
});

/**
 * Check if the sidebar menu is enabled
 * @returns {boolean}
 */
export const sidebarEnabled = computed(() => {
  return !!store.getters.layoutConfig("aside.display");
});

/**
 * Set the sidebar theme
 * @returns {string}
 */
export const sidebarTheme = computed(() => {
  return store.getters.layoutConfig("aside.theme");
});

/**
 * Set the subheader display
 * @returns {boolean}
 */
export const subheaderDisplay = computed(() => {
  return store.getters.layoutConfig("toolbar.display");
});

/**
 * Set the sidebar menu icon type
 * @returns {string}
 */
export const sidebarMenuIcons = computed(() => {
  return store.getters.layoutConfig("sidebar.default.menu.iconType");
});

/**
 * Light theme logo image
 * @returns {string}
 */
export const themeLightLogo = computed(() => {
  return store.getters.layoutConfig("main.logo.light");
});

/**
 * Dark theme logo image
 * @returns {string}
 */
export const themeDarkLogo = computed(() => {
  return store.getters.layoutConfig("main.logo.dark");
});

/**
 * Set the header menu icon type
 * @returns {string}
 */
export const headerMenuIcons = computed(() => {
  return store.getters.layoutConfig("header.default.menu.iconType");
});

/**
 * Set the header menu display
 * @returns {string}
 */
export const headerMenuDisplay = computed(() => {
  return store.getters.layoutConfig("header.default.menu.display");
});

/**
 * Page title display
 * @returns {boolean}
 */
export const pageTitleDisplay = computed(() => {
  return store.getters.layoutConfig("pageTitle.display");
});

/**
 * Page title breadcrumb display
 * @returns {boolean}
 */
export const pageTitleBreadcrumbDisplay = computed(() => {
  return store.getters.layoutConfig("pageTitle.breadcrumb");
});

/**
 * Page title direction display
 * @returns { "row" | "column" }
 */
export const pageTitleDirection = computed(() => {
  return store.getters.layoutConfig("pageTitle.direction");
});

/**
 * Scrolltop display
 * @returns {boolean}
 */
export const scrolltopDispaly = computed(() => {
  return store.getters.layoutConfig("scrolltop.display");
});

/**
 * Illustrations set
 * @returns {string}
 */
export const illustrationsSet = computed(() => {
  return store.getters.layoutConfig("illustrations.set");
});
