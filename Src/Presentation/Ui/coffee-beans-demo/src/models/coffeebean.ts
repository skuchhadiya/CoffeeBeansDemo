import type { EditableCoffeeBeanProduct } from './editableCoffeeBeanProduct'

export interface CoffeeBean extends EditableCoffeeBeanProduct {
  id: string
  index: number
}
