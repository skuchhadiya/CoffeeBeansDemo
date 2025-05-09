<template>
  <span>
    <img
      @click="openModal"
      class="rounded-full"
      style="height: 24px; width: 24px; cursor: pointer"
      src="../assets/icons/trash.svg"
      title="Delete"
      alt="Delete"
    />
  </span>
  <DialogComponent
    v-bind:isOpen="isOpen"
    titleText="Confirm Dialog"
    :dialogText="dialogText"
    okButtonText="Confirm"
    :close="closeModal"
  ></DialogComponent>
</template>
<script lang="ts">
import { defineComponent } from 'vue'
import DialogComponent from '@/components/DialogComponent.vue'
import { removeCoffeeBeanProduct } from '../services/data.service'
import router from '@/router'
export default defineComponent({
  name: 'CustomButtonComponent',
  components: { DialogComponent },
  data() {
    return {
      isOpen: false,
      loading: false,
      dialogText: '',
    }
  },
  methods: {
    closeModal(value: boolean) {
      this.isOpen = false
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      const id = (this.$props as any).params.data.id
      if (value && id) {
        this.isOpen = true
        // here we can use rxjs
        removeCoffeeBeanProduct(id)
          .then((response) => {
            this.loading = false
            this.isOpen = false
            if (response.data > 0) {
              alert('Item deleted successfully!!')
            }
            router.go(0)
          })
          .catch((error) => {
            this.loading = false
            this.isOpen = false
            alert('Error while deleting!')
            console.error(error)
            router.go(0)
          })
      }
    },
    openModal() {
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      this.dialogText = `Are tou sure you want to delete this Product Name:${(this.$props as any).params.data.name} ?`
      this.isOpen = true
    },
  },
})
</script>
