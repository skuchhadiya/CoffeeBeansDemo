<template>
  <span>
    <router-link
      :to="{
        name: 'EditProduct',
        query: ($props as any).params.data,
      }"
      ><img
        class="rounded-full"
        style="height: 24px; width: 24px; cursor: pointer"
        src="../assets/icons/pencil.svg"
        title="Edit"
        alt="Edit"
    /></router-link>
  </span>
</template>
<script lang="ts">
import { defineComponent } from 'vue'
export default defineComponent({
  name: 'CustomEditButtonComponent',
})
</script>
