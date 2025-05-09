import type { CoffeeBean } from '@/models/coffeebean'
import { defineStore } from 'pinia'

export const productStore = defineStore('productsdata', {
  state: () => ({
    products: [] as CoffeeBean[],
  }),
  getters: {
    getProducts: (state) => state.products,
  },
  actions: {
    setProducts(products: CoffeeBean[]) {
      console.log(products)
      this.products = Object.assign({}, products)
    },
  },
})
