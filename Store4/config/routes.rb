Rails.application.routes.draw do
  devise_for :users
  get 'welcome/index'

  resources :products
  root 'welcome#index'
  root 'home#index'
end
