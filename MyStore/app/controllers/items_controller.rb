class ItemsController < ApplicationController

  def index
    #@item=Item.all
    render text: "item"#@items.map{|i| "#{i.name}: #{i.price}"}.join("<br/>")
  end

  def create
    @item=Item.create(name: params[:name], description: params[:description], price: params[:price], real: params[:real],
                weight: params[:weight])
   render text: "#{@item.id}: #{@item.name} (#{!@item.new_record?})"
  end
end
