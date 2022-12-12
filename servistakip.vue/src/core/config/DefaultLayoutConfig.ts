import LayoutConfigTypes from "@/core/config/LayoutConfigTypes";

const config: LayoutConfigTypes = {
  general: {
    mode: "light",
    primaryColor: "#50CD89",
    pageWidth: "fluid",
    layout: "light-header",
  },
  header: {
    display: true,
    default: {
      container: "fluid",
      fixed: {
        desktop: true,
        mobile: false,
      },
      menu: {
        display: true,
        iconType: "svg",
      },
    },
  },
  sidebar: {
    display: true,
    default: {
      minimize: {
        desktop: {
          enabled: true,
          default: false,
          hoverable: true,
        },
      },
      menu: {
        iconType: "svg",
      },
    },
  },
  toolbar: {
    display: true,
    container: "fluid",
    fixed: {
      desktop: false,
      mobile: false,
    },
  },
  pageTitle: {
    display: true,
    breadcrumb: true,
    direction: "column",
  },
  content: {
    container: "fluid",
  },
  footer: {
    display: true,
    container: "fluid",
    fixed: {
      desktop: false,
      mobile: false,
    },
  },
  illustrations: {
    set: "sketchy-1",
  },
  scrolltop: {
    display: true,
  },
};

export default config;
