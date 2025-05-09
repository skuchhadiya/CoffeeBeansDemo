import axios from 'axios'
import { API } from '../shared/config'
import type { CoffeeBean } from '@/models/coffeebean'
import type { EditableCoffeeBeanProduct } from '@/models/editableCoffeeBeanProduct'

// for time constraint i will assume all service working correctly so not adding test
export const getProducts = async function (): Promise<{ data: CoffeeBean[] }> {
  try {
    const url = `${API}/api/CoffeeBeans`
    console.log(url)
    const response = await axios.get(url)
    return response
  } catch (error) {
    console.error(error)
    return { data: [] }
  }
}

export const getBOTDProductDetail = async function (): Promise<{ data: string }> {
  try {
    const url = `${API}/api/CoffeeBeans/botd`
    console.log(url)
    const response = await axios.get(url)
    return response
  } catch (error) {
    console.error(error)
    return { data: '' }
  }
}

export const addNewCoffeeBeanProduct = async function (
  data: EditableCoffeeBeanProduct,
): Promise<{ data: CoffeeBean[] }> {
  try {
    const url = `${API}/api/CoffeeBeans`
    console.log(url)
    const response = await axios.put(url, data)
    return response
  } catch (error) {
    console.error(error)
    return { data: [] }
  }
}

export const editCoffeeBeanProduct = async function (data: CoffeeBean): Promise<number> {
  console.log(data)
  try {
    const url = `${API}/api/CoffeeBeans`
    console.log(url)
    const response = await axios.post(url, data)
    return response.data
  } catch (error) {
    console.error(error)
    return 0
  }
}

export const removeCoffeeBeanProduct = async function (id: string): Promise<{ data: number }> {
  try {
    const url = `${API}/api/CoffeeBeans/${id}`
    console.log(url)
    const response = await axios.delete(url)
    return response
  } catch (error) {
    console.error(error)
    return { data: 0 }
  }
}
