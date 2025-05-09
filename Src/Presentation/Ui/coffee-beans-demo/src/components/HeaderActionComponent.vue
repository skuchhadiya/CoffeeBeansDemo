<template>
  <router-link to="/new-product"><PlusIcon class="size-5" aria-hidden="true" /></router-link>
</template>
<script lang="ts">
import { PlusIcon } from '@heroicons/vue/20/solid'
import { defineComponent } from 'vue'
export default defineComponent({
  name: 'HeaderActionComponent',
  components: { PlusIcon },
})
</script>
