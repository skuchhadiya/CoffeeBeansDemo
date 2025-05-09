<template>
  <ProductDetailEditorComponent
    title="Edit Coffeebean product"
    buttonText="Edit"
    :editableProduct="$route.query"
    :loading="loading"
    :handleSubmit="handleSubmit"
  ></ProductDetailEditorComponent>
</template>
<script lang="ts">
import { editCoffeeBeanProduct } from '../services/data.service.ts'
import type { EditableCoffeeBeanProduct } from '@/models/editableCoffeeBeanProduct.ts'
import ProductDetailEditorComponent from '@/components/ProductDetailEditorComponent.vue'
import type { CoffeeBean } from '@/models/coffeebean.ts'
import { defineComponent } from 'vue'
import router from '@/router/index.ts'
export default defineComponent({
  name: 'EditProductView',
  components: {
    ProductDetailEditorComponent,
  },
  props: ['product', 'header'],
  methods: {
    handleSubmit(product: EditableCoffeeBeanProduct) {
      const editedProduct = {
        ...product,
      } as CoffeeBean
      this.loading = true
      editCoffeeBeanProduct(editedProduct)
        .then(() => {
          this.loading = false
          router.go(-1)
        })
        .catch((error) => {
          this.loading = false
          console.error(error)
          router.go(-1)
        })
    },
  },
  data() {
    return {
      loading: false,
    }
  },
})
</script>
