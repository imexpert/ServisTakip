<template>
  <input class="form-control form-control-sm border border-secondary" ref="inputRef" type="text" />
</template>

<script>
import { useCurrencyInput } from 'vue-currency-input';

export default {
  name: 'CurrencyInput',
  props: {
    modelValue: Number, // Vue 2: value
    options: Object,
  },
  setup(props) {
    const { inputRef } = useCurrencyInput(props.options);

    return { inputRef };
  },
};
</script>
