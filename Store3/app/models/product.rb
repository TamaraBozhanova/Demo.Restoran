class Product < ApplicationRecord
  validates :name, presence: true
  validates :price, numericality: {greater_than: 0, allow_nil: true}
  validates :weight, numericality: {greater_than: 0, allow_nil: true}
end
