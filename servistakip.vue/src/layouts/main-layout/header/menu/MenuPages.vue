<template>
  <template v-for="(item, i) in MainMenuConfig" :key="i">
    <template v-if="!item.heading">
      <template v-for="(menuItem, j) in item.pages" :key="j">
        <div v-if="menuItem.heading" class="menu-item me-lg-1">
          <router-link class="menu-link" :to="menuItem.route" active-class="active">
            <span class="menu-title">{{ translate(menuItem.heading) }}</span>
          </router-link>
        </div>
      </template>
    </template>
  </template>

  <div
    data-kt-menu-trigger="click"
    data-kt-menu-placement="bottom-start"
    class="menu-item menu-lg-down-accordion me-lg-1"
  >
    <span class="menu-link py-3">
      <span class="menu-title">{{ translate('reports') }}</span>
      <span class="menu-arrow d-lg-none"></span>
    </span>
    <div class="menu-sub menu-sub-lg-down-accordion menu-sub-lg-dropdown w-100 w-lg-250px p-5 p-lg-5" style="">
      <!--begin:Row-->
      <div class="row" data-kt-menu-dismiss="true">
        <!--begin:Col-->
        <div class="col-lg-12 border-left-lg-1">
          <div class="menu-inline menu-column menu-active-bg">
            <div class="menu-item">
              <a href="/sozlesmeBasim" class="menu-link">
                <span class="menu-bullet">
                  <span class="bullet bullet-dot"></span>
                </span>
                <span class="menu-title">{{ translate('sozlesmeBasimRaporu') }}</span>
              </a>
            </div>
            <div class="menu-item">
              <a href="#" class="menu-link">
                <span class="menu-bullet">
                  <span class="bullet bullet-dot"></span>
                </span>
                <span class="menu-title">{{ translate('kopyabasiAnaliz') }}</span>
              </a>
            </div>
            <div class="menu-item">
              <a href="/bakimRaporu" class="menu-link">
                <span class="menu-bullet">
                  <span class="bullet bullet-dot"></span>
                </span>
                <span class="menu-title">{{ translate('bakimRaporu') }}</span>
              </a>
            </div>
            <div class="menu-item">
              <a href="#" class="menu-link">
                <span class="menu-bullet">
                  <span class="bullet bullet-dot"></span>
                </span>
                <span class="menu-title">{{ translate('sozlesmeRaporu') }}</span>
              </a>
            </div>
            <div class="menu-item">
              <a href="/musteriRaporu" class="menu-link">
                <span class="menu-bullet">
                  <span class="bullet bullet-dot"></span>
                </span>
                <span class="menu-title">{{ translate('musteriRaporu') }}</span>
              </a>
            </div>
            <div class="menu-item">
              <a href="#" class="menu-link">
                <span class="menu-bullet">
                  <span class="bullet bullet-dot"></span>
                </span>
                <span class="menu-title">{{ translate('kitDegisimRaporu') }}</span>
              </a>
            </div>
            <div class="menu-item">
              <a href="#" class="menu-link">
                <span class="menu-bullet">
                  <span class="bullet bullet-dot"></span>
                </span>
                <span class="menu-title">{{ translate('tonerDegisimRaporu') }}</span>
              </a>
            </div>
            <div class="menu-item">
              <a href="#" class="menu-link">
                <span class="menu-bullet">
                  <span class="bullet bullet-dot"></span>
                </span>
                <span class="menu-title">{{ translate('teknisyenAnalizDegisimRaporu') }}</span>
              </a>
            </div>
          </div>
        </div>
        <!--end:Col-->
      </div>
      <!--end:Row-->
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useRoute } from 'vue-router';
import { useI18n } from 'vue-i18n';
import MainMenuConfig from '@/core/config/MainMenuConfig';
import { headerMenuIcons } from '@/core/helpers/config';

export default defineComponent({
  name: 'KTMenu',
  components: {},
  setup() {
    const { t, te } = useI18n();
    const route = useRoute();

    const hasActiveChildren = match => {
      return route.path.indexOf(match) !== -1;
    };

    const translate = text => {
      if (te(text)) {
        return t(text);
      } else {
        return text;
      }
    };

    return {
      hasActiveChildren,
      headerMenuIcons,
      MainMenuConfig,
      translate,
    };
  },
});
</script>
